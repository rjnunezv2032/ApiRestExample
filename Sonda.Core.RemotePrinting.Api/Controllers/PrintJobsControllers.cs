using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.DTO;
using Sonda.Core.RemotePrinting.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{
    public class PrintJobsControllers : Base.GenericController<TrabajosImpresion, CodAgenteIpImpresoraKey>
    {

        private readonly IPrintJobsInfoBO _PrintJobsInfoBO;
        private readonly IPrintJobsBO _PrintJobsBO;

        public PrintJobsControllers(ILogger<PrintJobsControllers> logger,
            IPrintJobsInfoBO PrintJobsInfoBO,
            IPrintJobsBO PrintJobsBO,
            IGenericBO<TrabajosImpresion, CodAgenteIpImpresoraKey> genericBO,
            IUnitOfWork unitOfWork
          ) : base(logger, genericBO, unitOfWork)
        {
            this._PrintJobsInfoBO = PrintJobsInfoBO;
            this._PrintJobsBO = PrintJobsBO;

        }

        [HttpPost]
        [Route("GetPrintJobs")]
        [SwaggerOperation(Summary = "GetPrintJobs", Description = "GetPrintJobs")]
        public async Task<IActionResult> GetPrintJobs(CodAgenteIpImpresoraKey filtros)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PrintJobsBO.GetPrintJobs(filtros);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("SetPrintJobs")]
        [SwaggerOperation(Summary = "SetPrintJobs", Description = "SetPrintJobs")]
        public async Task<IActionResult> SetPrintJobs(List<TrabajosImpresion> PrintJobs)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                await this._PrintJobsBO.SetPrintJobs(PrintJobs);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("UpdatePrintJobs")]
        [SwaggerOperation(Summary = "UpdatePrintJobs", Description = "UpdatePrintJobs")]
        public async Task<IActionResult> UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                await this._PrintJobsBO.UpdatePrintJobs(InPut);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("GetDeleteJobsInfo")]
        [SwaggerOperation(Summary = "GetDeleteJobsInfo", Description = "Devuelve la constante de configuracion ConstantSettings.EliminarFisicamente desde el archivo appsetting.json")]
        public async Task<IActionResult> GetDeleteJobsInfo()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PrintJobsBO.GetDeleteJobsInfo();
            });
            return res.GetStatus(this);
        }
    }
}
