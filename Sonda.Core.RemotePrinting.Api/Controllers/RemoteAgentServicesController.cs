using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Newtonsoft.Json;
using Sonda.Core.RemotePrinting.Settings;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{

    [Route("ws/v{version}/[controller]")]
    //[ApiController]
    public class RemoteAgentServicesController : Base.GenericController<TrabajosImpresion, CodAgenteIpImpresoraKey>
    {
        private enum Command
        {
            CloseSocket,
            GetPrintingJobs,
            UpdatePrintingJobs,
            UpdatePrinterStatus
        }

        private class AgentCommand
        {
            public Command Command { get; set; }
            public Dictionary<string, object> Parameters { get; set; }

            public List<IdTrabajoIdImpresoraKey> Jobs { get; set; }

            public List<IdPrinterIdAgentIdStatusKey> PrintersStatus { get; set; }
        }

        private readonly IPrintJobsBO _PrintJobsBO;
        private readonly IPrinterBO _PrinterBO;
        private readonly new ILogger<RemoteAgentServicesController> _logger;
        private readonly int BufferSize;
        private CancellationTokenSource _cancellationToken;
        public RemoteAgentServicesController(ILogger<RemoteAgentServicesController> logger,
        IPrintJobsInfoBO PrintJobsInfoBO,
        IPrintJobsBO PrintJobsBO,
        IPrinterBO PrinterBO,
        IGenericBO<TrabajosImpresion, CodAgenteIpImpresoraKey> genericBO,
        IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._PrintJobsBO = PrintJobsBO;
            this._PrinterBO = PrinterBO;
            this._logger = logger;
            BufferSize = ConstantSettings.BufferSize;
        }


        [HttpGet]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var websocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _cancellationToken = new CancellationTokenSource();
                await ProcessInputRemoteCommand(websocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }


        private async Task ProcessInputRemoteCommand(WebSocket webSocket)
        {
            try
            {
                bool continuar = true;
                int counter = 0;
                int auxcounter = 0;
                while (webSocket.State == WebSocketState.Open)
                {
                    System.Diagnostics.Debug.WriteLine($"process input command steps: {counter}");
                    counter++;
                    
                    
                    var buffer = new byte[BufferSize];
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    
                    if (result == null) {
                        System.Diagnostics.Debug.WriteLine($" result == null : {auxcounter}");
                        auxcounter++;
                        //break;
                        return;
                     }
                    
                    var rawCommand = Encoding.UTF8.GetString(buffer);
                    AgentCommand objCommand = JsonConvert.DeserializeObject<AgentCommand>(rawCommand);

                    var aux = Task.Run<string>(() =>
                    {
                        return ProcessCommand(objCommand);
                    });
                    
                    
                    var serverMsg = Encoding.UTF8.GetBytes(aux.Result + "\r\r\r\r");
                    int maxSize = aux.Result.Length;
                    int size = (maxSize < (BufferSize * 512) ? maxSize : (BufferSize * 512));
                    int offset = 0;
                    var seg = new ArraySegment<byte>(serverMsg, offset, (size > (maxSize - offset) ? (maxSize - offset) : size));
                    do
                    {
                        seg = new ArraySegment<byte>(serverMsg, offset, (size>(maxSize-offset)?(maxSize-offset):size));
                        await webSocket.SendAsync(seg, WebSocketMessageType.Text, true, CancellationToken.None);
                        offset = offset + (BufferSize * 512);
                        if (offset >= maxSize)
                        {
                            continuar = false;
                        }

                    } while (continuar);
                    if (continuar == false)
                    {
                        await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "<EOS>", CancellationToken.None);
                    }

                }              
            }
            catch (WebSocketException wx)
            {
                _logger.LogError(wx.Message, wx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            finally {}
        }

        private async Task<string> GetPrintingJobs(AgentCommand command)
        {
            Repository.PrintJobsRepository printJobRepo = new Repository.PrintJobsRepository(_unitOfWork);

            CodAgenteIpImpresoraKey filtro = new CodAgenteIpImpresoraKey()
            {
                CodAgente = command.Parameters["codAgente"].ToString(),
                IpAgente = command.Parameters["ipAgente"].ToString(),
                Expand = command.Parameters["expand"].ToString()
            };
            var result = await printJobRepo.GetPrintJobs((CodAgenteIpImpresoraKey)filtro);

            var x = new
            {
                callbackCommand = Enum.GetName(typeof(Command), command.Command),
                result = result
            };


            return JsonConvert.SerializeObject(x, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        private async Task<string> UpdatePrintingJobs(List<IdTrabajoIdImpresoraKey> jobs, AgentCommand command)
        {
            var result = await _unitOfWork.Execute(async () =>
            {
                foreach (IdTrabajoIdImpresoraKey filtro in jobs)
                {
                    await _PrintJobsBO.UpdatePrintJobs(filtro);
                }
            });
            var x = new
            {
                callbackCommand = Enum.GetName(typeof(Command), command.Command),
                result = result.Messages
            };
            return JsonConvert.SerializeObject(x);
        }

        private async Task<string> UpdatePrintingJobs(AgentCommand command)
        {
            var result = string.Empty;
            IdTrabajoIdImpresoraKey filtro = new IdTrabajoIdImpresoraKey()
            {
                IdTrabajo = Convert.ToInt32(command.Parameters["idTrabajo"].ToString()),
                IdEstadoImpresion = Convert.ToInt32(command.Parameters["idEstadoImpresion"].ToString()),
                IdImpresora = Convert.ToInt32(command.Parameters["idImpresora"].ToString()),
                PosColaImpresion = Convert.ToInt32(command.Parameters["posColaImpresion"].ToString()),
                fechaImpresion = Convert.ToDateTime(command.Parameters["fechaImpresion"]),
                Expand = command.Parameters["expand"].ToString()
            };

            var res2 = await _unitOfWork.Execute(async () =>
            {
                await _PrintJobsBO.UpdatePrintJobs(filtro);
            });
            if (res2.ErrorCode == null)
            {
                if (res2.Messages.Count > 0)
                {
                    result = res2.Messages[0].Message;
                }
                else
                {
                    result = "ok";
                }
            }
            else
            {
                result = res2.ErrorMessage;
            }
            var x = new
            {
                callbackCommand = Enum.GetName(typeof(Command), command.Command),
                result = result
            };
            return JsonConvert.SerializeObject(x);
        }

        private async Task<string> UpdatePrinterStatus(AgentCommand command)
        {

            var result = await _unitOfWork.Execute(async () =>
            {
                foreach (IdPrinterIdAgentIdStatusKey printerKey in command.PrintersStatus)
                {
                    IdAgenteIdPrinterStatusKey filter = new IdAgenteIdPrinterStatusKey()
                    {
                        IdAgent = printerKey.IdAgente,
                        IdPrinter = printerKey.IdImpresora,
                        IdStatus = printerKey.idEstadoImpresora
                    };
                    await _PrinterBO.UpdatePrinterStatus(filter);
                }
            });

            var x = new
            {
                callbackCommand = Enum.GetName(typeof(Command), command.Command),
                result = _unitOfWork.Messages
            };
            return JsonConvert.SerializeObject(x);
        }


        private Task<string> ProcessCommand(AgentCommand command)
        {
            try
            {
                string result = string.Empty;
                switch (command.Command)
                {
                    case Command.UpdatePrinterStatus:
                        result = UpdatePrinterStatus(command).Result;
                        break;
                    case Command.GetPrintingJobs:
                        result = GetPrintingJobs(command).Result;
                        break;
                    case Command.UpdatePrintingJobs:
                        if (command.Jobs.Count > 0)
                        {
                            result = UpdatePrintingJobs(command.Jobs, command).Result;
                        }
                        else
                        {
                            result = UpdatePrintingJobs(command).Result;
                        }
                        break;
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, command);
                return Task.FromResult($"fail on command: {command.Command}");
            }
        }
    }
}
