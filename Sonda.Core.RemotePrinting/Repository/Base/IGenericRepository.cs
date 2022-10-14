using Sonda.Api.Common.Helper.Services;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository.Base
{
    public interface IGenericRepository<TEntity, TKey> : ISondaCoreRepository where TKey : IKey
    {
        Task<IEnumerable<TEntity>> Search(QueryOptions options);
        Task<TEntity> Get(TKey key);
        Task Delete(TKey key);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> Search();
        Task<IEnumerable<TEntity>> Search(string filter);
        Task<IEnumerable<TEntity>> Search(string filter, string expands);
    }
}
