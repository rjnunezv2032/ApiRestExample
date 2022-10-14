using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Sonda.Core.RemotePrinting.Repository
{
    public class EstadosImpresorasRepository : GenericRepository<EstadosImpresorasDTO, IdEstadoImpresoraKey>, IEstadosImpresorasRepository
    {
        public EstadosImpresorasRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<EstadosImpresorasDTO>> GetAll()
        {
            var query = Session.Query<EstadosImpresorasDTO>();

            return await query.ToListAsync();
        }
    }
}
