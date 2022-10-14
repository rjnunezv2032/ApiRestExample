using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IPropositoRepository : IGenericRepository<PropositoDTO, IdPropositoKey>
    {
        Task<IEnumerable<PropositoDTO>> GetAll();
    }
}
