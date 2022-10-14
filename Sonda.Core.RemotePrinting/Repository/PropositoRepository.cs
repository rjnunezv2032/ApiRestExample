using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class PropositoRepository : GenericRepository<PropositoDTO, IdPropositoKey>, IPropositoRepository
    {
        public PropositoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<PropositoDTO>> GetAll()
        {
            var query = Session.Query<PropositoDTO>();

            return await query.ToListAsync();
        }
    }
}
