using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{
    [ApiVersion("1.0")]
    public class PrintersController : Base.GenericController<Printer, IdImpresoraKey>
    {
        private readonly IPrinterBO _printerBO;

        public PrintersController(ILogger<PrintersController> logger,
            IPrinterBO printerBO,
            IGenericBO<Printer, IdImpresoraKey> genericBO,
            IUnitOfWork unitOfWork
          ) : base(logger, genericBO, unitOfWork)
        {
            this._printerBO = printerBO;
        }

        //[HttpPost]
        //[Route("UpdatePrinterStatus")]
        //[SwaggerOperation(Summary = "UpdatePrinterStatus", Description = "Actualiza el estado de la impresora ")]
        //public async Task<IActionResult> UpdatePrinterStatus(IdAgenteIdPrinterStatusKey filtros)
        //{
        //    var res = await _unitOfWork.Execute(async () =>
        //    {
        //        await _printerBO.UpdatePrinterStatus(filtros);
        //    });
        //    return res.GetStatus(this);
        //}


        //[HttpPost]
        //[Route("GetPrinter")]
        //[SwaggerOperation(Summary ="GetPrinter",Description ="GetPrinter")]
        //public async Task<IActionResult> GetPrinter(IdImpresoraKey filtros)
        //{
        //    var res = await _unitOfWork.Execute(async () => {
        //        return await _printerBO.GetPrinter(filtros);
        //    });
        //    return res.GetStatus(this);
        //}
    }
}
