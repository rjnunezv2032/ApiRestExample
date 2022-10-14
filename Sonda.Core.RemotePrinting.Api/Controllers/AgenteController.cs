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
    public class AgenteController : Base.GenericController<Agente, IdAgenteKey>
    {

        private readonly IAgenteBO _AgenteBO;

        public AgenteController( ILogger<AgenteController> logger,
                                IAgenteBO AgenteBO,
                                IGenericBO<Agente, IdAgenteKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._AgenteBO = AgenteBO;
        }

        [HttpPost]
        [Route("RemovePrinter")]
        [SwaggerOperation(Summary = "RemovePrinter", Description = "Actualiza el estado de la impresora como eliminada")]
        public async Task<IActionResult> RemovePrinter(IdAgenteKey filtros)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                await _AgenteBO.RemovePrinter(filtros);
            });
            return res.GetStatus(this);
        }
    }
}
