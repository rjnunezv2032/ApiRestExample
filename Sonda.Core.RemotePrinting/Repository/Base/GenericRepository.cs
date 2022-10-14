using NHibernate;
using NHibernate.Linq;
using Sonda.Api.Common.Helper.Exceptions;
using Sonda.Api.Common.Helper.Services;
using Sonda.Core.Database.NH;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository.Base
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TKey : IKey
    {
        protected readonly IUnitOfWork _UnitOfWork;
        protected ISession _session;

        public GenericRepository(IUnitOfWork uow)
        {
            this._UnitOfWork = uow;
        }

        protected ISession Session
        {
            get
            {
                if (_session == null) _session = NhibernateHelper.InitSession<TEntity>(_UnitOfWork);
                return _session;
            }
        }

        async public virtual Task<IEnumerable<TEntity>> Search(QueryOptions options)
        {
            var q = Session.Query<TEntity>();

            if (HasInterface(typeof(TEntity), typeof(IStatus)))
            {
                options = AppendFilter(options, "Status != 0");
            }
            if (HasInterface(typeof(TEntity), typeof(ICamposControl)))
            {
                options = AppendFilter(options, "EstadoReg = \"V\"");
            }
            if (options != null) q = options.ApplyNH(q);
            var result = await q.ToListAsync();
            return result;
        }

        async public virtual Task<IEnumerable<TEntity>> Search()
        {
            return await Search(new QueryOptions());
        }

        async public virtual Task<TEntity> Create(TEntity entity)
        {
            if (HasInterface(typeof(TEntity), typeof(ICamposControl)))
            {
                ICamposControl camposControl = (ICamposControl)entity;
                camposControl.EstadoReg = "V";
                camposControl.FecEstadoReg = DateTime.Now;
                camposControl.FecIngReg = DateTime.Now;
            }
            if (HasInterface(typeof(TEntity), typeof(IStatus)))
            {
                IStatus status = (IStatus)entity;
                status.Status = -1;
            }

            try
            {
                await Session.SaveAsync(entity);
            }
            catch (NHibernate.Exceptions.GenericADOException e)
            {
                throw new SondaCoreException("SYS-00103", "No fue posible crear el registro. Revise el detalle del error para obtener mas información.", e);
            }

            _UnitOfWork.AddMessage("USU-00001", "El registro ha sido creado");
            return entity;
        }

        async public virtual Task Delete(TKey key)
        {
            var instancia = await Get(key);
            IStatus status = null;
            ICamposControl aux = null;

            if (instancia == null) throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");

            if (HasInterface(typeof(TEntity), typeof(IStatus)))
            {
                status = (IStatus)instancia;
                if (status == null || (status != null && status.Status == 0)) throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");
            }
            if (HasInterface(typeof(TEntity), typeof(ICamposControl)))
            {
                aux = (ICamposControl)instancia;
                if (aux == null || (aux != null && aux.EstadoReg != "V")) throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");
            }

            if (aux != null)
            {
                aux.EstadoReg = "E";
                aux.FecEstadoReg = DateTime.Now;
                aux.FecUltModifReg = DateTime.Now;
                await Session.UpdateAsync(aux);
            }
            else if (status != null)
            {
                status.Status = 0;
                await Session.UpdateAsync(status);
            }
            else
            {
                await Session.DeleteAsync(instancia);
            }
            _UnitOfWork.AddMessage("USU-00001", "El registro ha sido eliminado");

        }

        async public virtual Task<TEntity> Update(TEntity entity)
        {
            TEntity instancia;
            TEntity newEntity = default(TEntity);
            TEntity originalEntity = default(TEntity);

            if (!Session.Contains(entity))
            {
                newEntity = (TEntity)Activator.CreateInstance(typeof(TEntity));
                Reflection.CopyProperties(entity, newEntity);
                try
                {
                    await Session.RefreshAsync(entity);
                    originalEntity = (TEntity)Activator.CreateInstance(typeof(TEntity));
                    Reflection.CopyProperties(entity, originalEntity);
                }
                catch (NHibernate.UnresolvableObjectException)
                {
                    throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");
                }
            }
            instancia = entity;

            ICamposControl camposControl = null;
            IStatus status = null;

            if (instancia != null)
            {
                if (HasInterface(typeof(TEntity), typeof(IStatus)))
                {
                    status = (IStatus)instancia;
                    if (status != null && status.Status == 0) throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");
                }
                if (HasInterface(typeof(TEntity), typeof(ICamposControl)))
                {
                    camposControl = (ICamposControl)instancia;
                    if (camposControl != null && camposControl.EstadoReg != "V") throw new SondaCoreException("SYS-00102", "El registro que intenta eliminar/modificar no existe");
                }
            }

            if (newEntity != null)
            {
                Reflection.CopyProperties(newEntity, entity);
            }

            if (camposControl != null)
            {
                ICamposControl CamposControlIniciales = (ICamposControl)originalEntity;
                camposControl.EstadoReg = "V";
                camposControl.FecEstadoReg = DateTime.Now;
                camposControl.FecIngReg = CamposControlIniciales.FecIngReg;
                camposControl.FecUltModifReg = DateTime.Now;
                camposControl.IdUsuarioIngReg = CamposControlIniciales.IdUsuarioIngReg;
            }
            if (status != null)
            {
                status.Status = -1;
            }
            await Session.UpdateAsync(instancia);
            _UnitOfWork.AddMessage("USU-00001", "El registro ha sido modificado");
            return instancia;

        }

        public virtual async Task<TEntity> Get(TKey key)
        {
            var q = Session.Query<TEntity>();
            QueryOptions options = new()
            {
                Filter = key.ToString()
            };
            if (HasInterface(typeof(TEntity), typeof(IStatus)))
            {
                options = AppendFilter(options, "Status != 0");
            }
            if (HasInterface(typeof(TEntity), typeof(ICamposControl)))
            {
                options = AppendFilter(options, "EstadoReg = \"V\"");
            }
            if (!string.IsNullOrEmpty(key.Expand))
            {
                options.Expand = key.Expand;
            }

            q = options.ApplyNH(q);
            var result = await q.FirstOrDefaultAsync();
            return result;
        }

        async public virtual Task<IEnumerable<TEntity>> Search(string filter)
        {
            return await Search(new QueryOptions() { Filter = filter });
        }

        public async Task<IEnumerable<TEntity>> Search(string filter, string expands)
        {
            return await Search(new QueryOptions() { Filter = filter, Expand = expands });
        }

        private static QueryOptions AppendFilter(QueryOptions options, string filter)
        {
            if (options == null) options = new QueryOptions();

            if (string.IsNullOrWhiteSpace(options.Filter))
            {
                options.Filter = filter;
            }
            else
            {
                options.Filter = options.Filter + " and (" + filter + ")";
            }
            return options;
        }

        private bool HasInterface(Type type, Type interfaze)
        {
            return (System.Array.IndexOf(type.GetInterfaces(), interfaze) >= 0);
        }
    }
}
