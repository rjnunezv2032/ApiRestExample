using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface ITipoDocumentoRepository : IGenericRepository<TipoDocumentoDTO, IdTipoDocumentoKey>
    {
        Task<IEnumerable<TipoDocumentoDTO>> GetAll();
    }
}
