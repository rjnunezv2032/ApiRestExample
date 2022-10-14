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
    public class PropositoController : Base.GenericController<Proposito, IdPropositoKey>
    {

        private readonly IPropositoBO _PropositoBO;

        public PropositoController( ILogger<PropositoController> logger,
                                IPropositoBO PropositoBO,
                                IGenericBO<Proposito, IdPropositoKey> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this._PropositoBO = PropositoBO;
        }

        [HttpPost]
        [Route("GetAll")]
        [SwaggerOperation(Summary = "GetAll", Description = "Obtiene los propositos de las impresoras, vigenetes y no vigentes")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _PropositoBO.GetAll();
            });
            return res.GetStatus(this);
        }
    }
}
