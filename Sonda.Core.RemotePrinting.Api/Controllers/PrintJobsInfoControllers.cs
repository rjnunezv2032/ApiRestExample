using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.DTO;
using Sonda.Core.RemotePrinting.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{
    public class PrintJobsInfoControllers : Base.GenericController<PrintJobsInfo, IdUsuarioKey>
    {

        private readonly IPrintJobsInfoBO _PrintJobsInfoBO;

        public PrintJobsInfoControllers(ILogger<PrintJobsInfoControllers> logger,
            IPrintJobsInfoBO PrintJobsInfoBO,
            IGenericBO<PrintJobsInfo, IdUsuarioKey> genericBO,
            IUnitOfWork unitOfWork
          ) : base(logger, genericBO, unitOfWork)
        {
            this._PrintJobsInfoBO = PrintJobsInfoBO;

        }

        [HttpPost]
        [Route("GetPrintJobsInfo")]
        [SwaggerOperation(Summary = "GetPrintJobsInfo", Description = "GetPrintJobsInfo")]
        public async Task<IActionResult> GetPrintJobsInfo(IdUsuarioKey filtros)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PrintJobsInfoBO.GetPrintJobsInfo(filtros);
            });
            return res.GetStatus(this);
        }
    }
}
