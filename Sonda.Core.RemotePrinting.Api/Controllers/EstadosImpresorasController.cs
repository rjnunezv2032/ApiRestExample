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
    public class EstadosImpresorasController : Base.GenericController<EstadosImpresoras, IdEstadoImpresoraKey>
    {
        private readonly IEstadosImpresorasBO _estadosImpresorasBO;

        public EstadosImpresorasController(ILogger<EstadosImpresorasController> logger,
            IEstadosImpresorasBO estadosImpresorasBO,
            IGenericBO<EstadosImpresoras, IdEstadoImpresoraKey> genericBO,
            IUnitOfWork unitOfWork
          ) : base(logger, genericBO, unitOfWork)
        {
            this._estadosImpresorasBO = estadosImpresorasBO;
        }

        [HttpPost]
        [Route("GetAll")]
        [SwaggerOperation(Summary = "GetAll", Description = "Obtiene los Estados de las Impresoras, vigenetes y no vigentes")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _estadosImpresorasBO.GetAll();
            });
            return res.GetStatus(this);
        }
    }
}
