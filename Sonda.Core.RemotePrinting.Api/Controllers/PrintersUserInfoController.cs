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
    public class PrintersUserInfoController : Base.GenericController<PrintersUserInfo, IdUsuarioKey>
    {
        private readonly IPrintersUserInfoBO _PrintersUserInfoBO;

        public PrintersUserInfoController( ILogger<PrintersUserInfoController> logger,
                                IPrintersUserInfoBO PrintersUserInfoBO,
                                IGenericBO<PrintersUserInfo, IdUsuarioKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._PrintersUserInfoBO = PrintersUserInfoBO;
        }

        [HttpPost]
        [Route("GetUserPrinters")]
        [SwaggerOperation(Summary = "GetUserPrinters", Description = "GetUserPrinters")]
        public async Task<IActionResult> GetUserPrinters(IdUsuarioKey dataInput)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PrintersUserInfoBO.GetUserPrinters(dataInput);
            });
            return res.GetStatus(this);
        }
    }
}
