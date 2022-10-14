using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumentoDTO, IdTipoDocumentoKey>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<TipoDocumentoDTO>> GetAll()
        {
            var query = Session.Query<TipoDocumentoDTO>();

            return await query.ToListAsync();
        }
    }
}
