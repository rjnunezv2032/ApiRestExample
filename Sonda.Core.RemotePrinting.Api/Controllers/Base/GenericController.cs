using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Api.Common.Helper.Services;
using Sonda.Api.Common.Login;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Api.Controllers.Base
{
    public abstract class GenericController<TEntity, TKey> : SondaBaseController where TKey : IKey
    {
        protected readonly ILogger<GenericController<TEntity, TKey>> _logger;
        protected readonly IGenericBO<TEntity, TKey> _oBussinesObject;
        protected readonly IUnitOfWork _unitOfWork;
        //private ILogger<ReglaController> logger;
        //private IReglaBO reglaBO;
        //private IUnitOfWork uow;
        //private ILogger<ProcesoController> logger1;
        //private IGenericBO<Atributo, IdAdmCodAtributoKey> genericBO;
        //private IUnitOfWork unitOfWork;

        public GenericController(ILogger<GenericController<TEntity, TKey>> logger, IGenericBO<TEntity, TKey> bussinesObject, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _oBussinesObject = bussinesObject;
            _unitOfWork = unitOfWork;
        }
        /*
        protected GenericController(ILogger<ReglaController> logger, IReglaBO reglaBO, IUnitOfWork uow)
        {
            this.logger = logger;
            this.reglaBO = reglaBO;
            this.uow = uow;
        }

        protected GenericController(ILogger<ProcesoController> logger1, IGenericBO<Atributo, IdAdmCodAtributoKey> genericBO, IUnitOfWork unitOfWork)
        {
            this.logger1 = logger1;
            this.genericBO = genericBO;
            this.unitOfWork = unitOfWork;
        }*/

        [HttpPost]
        [Route("Search")]
        [SwaggerOperation(Summary = "Search", Description = "Busca con parámetros de paginacion, ordenamiento y filtro")]
        public async Task<IActionResult> Search([FromBody] QueryOptions options)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _oBussinesObject.Search(options);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("Get")]
        [SwaggerOperation(Summary = "Get", Description = "Trae una entidad por su Id")]
        public async Task<IActionResult> Get(TKey key)
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _oBussinesObject.Get(key);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("Create")]
        [SwaggerOperation(Summary = "Create", Description = "Crea una nueva entidad")]
        public async Task<IActionResult> Create(TEntity entity)
        {
            _unitOfWork.IsTransactional = true;
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _oBussinesObject.Create(entity);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("Update")]
        [SwaggerOperation(Summary = "Update", Description = "Modifica una entidad existente")]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            _unitOfWork.IsTransactional = true;
            var res = await _unitOfWork.Execute(async () =>
            {
                return await _oBussinesObject.Update(entity);
            });
            return res.GetStatus(this);
        }

        [HttpPost]
        [Route("Delete")]
        [SwaggerOperation(Summary = "Delete", Description = "Elimina una entidad por su id")]
        public async Task<IActionResult> Delete(TKey key)
        {
            _unitOfWork.IsTransactional = true;
            var res = await _unitOfWork.Execute(async () =>
            {
                await _oBussinesObject.Delete(key);
            });
            return res.GetStatus(this);
        }
    }
}