using AutoMapper;
using Sonda.Api.Common.Helper.Exceptions;
using Sonda.Core.DbConn.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Repository;

using Sonda.Api.Common.Helper.Services;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Model.Input;
using MediatR;

namespace Sonda.Core.RemotePrinting.Business.Base
{
    /// <summary>
    /// Defines the <see cref="GenericBO{TEntity,TDAO,TKey}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    /// <typeparam name="TDAO">.</typeparam>
    /// <typeparam name="TKey">.</typeparam>
    public class GenericBO<TEntity, TDAO, TKey> : IGenericBO<TEntity, TKey> where TKey : IKey
    {
        /// <summary>
        /// Defines the _UnitOfWork.
        /// </summary>
        protected readonly IUnitOfWork _UnitOfWork;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Defines the _oRepository.
        /// </summary>
        protected readonly IGenericRepository<TDAO, TKey> _oRepository;

        /// <summary>
        /// Defines the _mediator.
        /// </summary>
        protected readonly IMediator _mediator;

        /// <summary>
        /// Defines the _invalidHandlers.
        /// </summary>
        private static List<string> _invalidHandlers = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericBO{TEntity,TDAO,TKey}"/> class.
        /// </summary>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        /// <param name="uow">The uow<see cref="IUnitOfWork"/>.</param>
        /// <param name="repository">The repository<see cref="IGenericRepository{TDAO,TKey}"/>.</param>
        /// <param name="mediator">The mediator<see cref="IMediator"/>.</param>
        public GenericBO(IMapper mapper, IUnitOfWork uow, IGenericRepository<TDAO, TKey> repository, IMediator mediator)
        {
            this._UnitOfWork = uow;
            this._oRepository = repository;
            this._mapper = mapper;
            this._mediator = mediator;
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        async virtual public Task<TEntity> Create(TEntity entity)
        {
            TDAO dao = _mapper.Map<TDAO>(entity);
            dao = await TryCallHandler("Create", entity, dao, null);
            return _mapper.Map<TEntity>(await _oRepository.Create(dao));
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="key">The key<see cref="TKey"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        async virtual public Task Delete(TKey key)
        {
            TDAO dao = await _oRepository.Get(key);
            dao = await TryCallHandler("Delete", null, dao, key);
            await _oRepository.Delete(key);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        async virtual public Task<TEntity> Update(TEntity entity)
        {
            TDAO dao = _mapper.Map<TDAO>(entity);
            dao = await TryCallHandler("Update", entity, dao, null);
            return _mapper.Map<TEntity>(await _oRepository.Update(dao));
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TEntity}}"/>.</returns>
        async virtual public Task<IEnumerable<TEntity>> Search()
        {
            return _mapper.Map<IEnumerable<TEntity>>(await _oRepository.Search());
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="filter">The filter<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{TEntity}}"/>.</returns>
        async virtual public Task<IEnumerable<TEntity>> Search(string filter)
        {
            return _mapper.Map<IEnumerable<TEntity>>(await _oRepository.Search(filter));
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="filter">The filter<see cref="string"/>.</param>
        /// <param name="expands">The expands<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{TEntity}}"/>.</returns>
        async virtual public Task<IEnumerable<TEntity>> Search(string filter, string expands)
        {
            return _mapper.Map<IEnumerable<TEntity>>(await _oRepository.Search(filter, expands));
        }

        // los siguientes dos metodos no se pudieron poner como 'public virtual'
        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="options">The options<see cref="QueryOptions"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{TEntity}}"/>.</returns>
        async Task<IEnumerable<TEntity>> IGenericBO<TEntity, TKey>.Search(QueryOptions options)
        {
            return _mapper.Map<IEnumerable<TEntity>>(await _oRepository.Search(options));
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="key">The key<see cref="TKey"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        async Task<TEntity> IGenericBO<TEntity, TKey>.Get(TKey key)
        {
            return _mapper.Map<TEntity>(await _oRepository.Get(key));
        }

        /// <summary>
        /// The TryCallHandler.
        /// </summary>
        /// <param name="Command">The Command<see cref="string"/>.</param>
        /// <param name="entity">The entity<see cref="object"/>.</param>
        /// <param name="dao">The dao<see cref="TDAO"/>.</param>
        /// <param name="key">The key<see cref="object"/>.</param>
        /// <returns>The <see cref="Task{TDAO}"/>.</returns>
        private async Task<TDAO> TryCallHandler(string Command, object entity, TDAO dao, object key)
        {

            var handlerKey = "";

            switch (Command)
            {
                case "Create":
                case "Update":
                    handlerKey = "${Command}-{entity.GetType().FullName}";
                    break;
                case "Delete":
                    handlerKey = "${Command}-{dao.GetType().FullName}";
                    break;
            }


            if (!_invalidHandlers.Contains(handlerKey))
            {
                try
                {
                    switch (Command)
                    {
                        case "Create":
                            dao = await _mediator.Send(new OnCreateCommand<TEntity, TDAO>((TEntity)entity, dao));
                            break;
                        case "Update":
                            dao = await _mediator.Send(new OnUpdateCommand<TEntity, TDAO>((TEntity)entity, dao));
                            break;
                        case "Delete":
                            dao = await _mediator.Send(new OnDeleteCommand<TKey, TDAO>((TKey)key, dao));
                            break;
                    }

                }
                catch (System.InvalidOperationException ex) when (ex.Message.StartsWith("Handler"))
                {
                    _invalidHandlers.Add(handlerKey);
                }
            }

            return dao;
        }
    }
}
