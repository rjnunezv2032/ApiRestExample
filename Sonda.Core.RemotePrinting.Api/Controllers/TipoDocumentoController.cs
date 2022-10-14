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
    public class TipoDocumentoController : Base.GenericController<TipoDocumento, IdTipoDocumentoKey>
    {

        private readonly ITipoDocumentoBO _TipoDocumentoBO;

        public TipoDocumentoController( ILogger<TipoDocumentoController> logger,
                                ITipoDocumentoBO TipoDocumentoBO,
                                IGenericBO<TipoDocumento, IdTipoDocumentoKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._TipoDocumentoBO = TipoDocumentoBO;
        }

        [HttpPost]
        [Route("GetAll")]
        [SwaggerOperation(Summary = "GetAll", Description = "Obtiene los Estados de Impresión, vigenetes y no vigentes")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _TipoDocumentoBO.GetAll();
            });
            return res.GetStatus(this);
        }
    }
}
