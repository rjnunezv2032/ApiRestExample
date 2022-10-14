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
    public class EstadosImpresionController : Base.GenericController<EstadosImpresion, IdEstadoImpresionKey>
    {
        private readonly IEstadosImpresionBO _estadosImpresionBO;
        public EstadosImpresionController(ILogger<EstadosImpresionController> logger,
            IEstadosImpresionBO estadosImpresionBO,
            IGenericBO<EstadosImpresion, IdEstadoImpresionKey> genericBO,
            IUnitOfWork unitOfWork
          ) : base(logger, genericBO, unitOfWork)
        {
            this._estadosImpresionBO = estadosImpresionBO;
        }

        [HttpPost]
        [Route("GetAll")]
        [SwaggerOperation(Summary = "GetAll", Description = "Obtiene los Estados de Impresión, vigenetes y no vigentes")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _estadosImpresionBO.GetAll();
            });
            return res.GetStatus(this);
        }
    }
}
