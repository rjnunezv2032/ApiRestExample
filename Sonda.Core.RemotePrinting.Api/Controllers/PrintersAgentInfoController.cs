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
    public class PrintersAgentInfoController : Base.GenericController<PrintersAgentInfo, IdAgenteKey>
    {
        private readonly IPrintersAgentInfoBO _PrintingAgentsInfoBO;

        public PrintersAgentInfoController( ILogger<PrintersAgentInfoController> logger,
                                IPrintersAgentInfoBO PrintingAgentsInfoBO,
                                IGenericBO<PrintersAgentInfo, IdAgenteKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._PrintingAgentsInfoBO = PrintingAgentsInfoBO;
        }

        [HttpPost]
        [Route("GetPrintersAgentInfo")]
        [SwaggerOperation(Summary = "GetPrintersAgentInfo", Description = "GetPrintersAgentInfo")]
        public async Task<IActionResult> GetPrintingAgentsInfo(IdAgenteKey dataInput)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PrintingAgentsInfoBO.GetPrintingAgentsInfo(dataInput);
            });
            return res.GetStatus(this);
        }
    }
}
