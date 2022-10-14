using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{
    [ApiVersion("1.0")]
    public class UserController : Base.GenericController<UsuarioImpresoras, IdKey>
    {
        private readonly IRegistryPrintUsersBO _RegistryPrintUsersBO;

        public UserController( ILogger<UserController> logger,
                               IRegistryPrintUsersBO RegistryPrintUsersBO,
                               IGenericBO<UsuarioImpresoras, IdKey> genericBO,
                               IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._RegistryPrintUsersBO = RegistryPrintUsersBO;
        }

        [HttpPost]
        [Route("UpdatePrintUser")]
        [SwaggerOperation(Summary = "UpdatePrintUser", Description = "Actuaiza una impresora por Usuario")]
        public async Task<IActionResult> UpdatePrintUser(IdAdmIdUsuarioIdImpresoraKey impresorasUsuario)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                await this._RegistryPrintUsersBO.UpdatePrintUser(impresorasUsuario);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("SetRegistryPrintUsers")]
        [SwaggerOperation(Summary = "SetRegistryPrintUsers", Description = "Crea las impresoras para un Usuario")]
        public async Task<IActionResult> SetRegistryPrintUsers(List<IdAdmIdUsuarioIdImpresoraKey> impresorasUsuario)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                await this._RegistryPrintUsersBO.SetRegistryPrintUsers(impresorasUsuario);
            });
            return res.GetStatus(this);
        }
    }
}
