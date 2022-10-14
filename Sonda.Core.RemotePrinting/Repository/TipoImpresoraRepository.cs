using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class TipoImpresoraRepository : GenericRepository<TipoImpresoraDTO, IdTipoImpresoraKey>, ITipoImpresoraRepository
    {
        public TipoImpresoraRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<TipoImpresoraDTO>> GetAll()
        {
            var query = Session.Query<TipoImpresoraDTO>();

            return await query.ToListAsync();
        }
    }
}
