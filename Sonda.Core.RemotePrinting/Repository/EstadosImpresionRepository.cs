using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class EstadosImpresionRepository : GenericRepository<EstadosImpresionDTO, IdEstadoImpresionKey>, IEstadosImpresionRepository
    {
        public EstadosImpresionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<EstadosImpresionDTO>> GetAll()
        {
            var query= Session.Query<EstadosImpresionDTO>();

            return await query.ToListAsync();
        }
    }
}
