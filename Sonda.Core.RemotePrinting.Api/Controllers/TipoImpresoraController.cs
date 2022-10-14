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
    public class TipoImpresoraController : Base.GenericController<TipoImpresora, IdTipoImpresoraKey>
    {

        private readonly ITipoImpresoraBO _TipoImpresoraBO;

        public TipoImpresoraController( ILogger<TipoImpresoraController> logger,
                                ITipoImpresoraBO TipoImpresoraBO,
                                IGenericBO<TipoImpresora, IdTipoImpresoraKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._TipoImpresoraBO = TipoImpresoraBO;
        }

        [HttpPost]
        [Route("GetAll")]
        [SwaggerOperation(Summary = "GetAll", Description = "Obtiene los Tipos de Impresioras, vigenetes y no vigentes")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _TipoImpresoraBO.GetAll();
            });
            return res.GetStatus(this);
        }
    }
}
