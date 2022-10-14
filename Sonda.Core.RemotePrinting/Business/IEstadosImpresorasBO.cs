using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{
    public interface IEstadosImpresorasBO : IGenericBO<EstadosImpresoras, IdEstadoImpresoraKey>
    {
        Task<IEnumerable<EstadosImpresoras>> GetAll();
    }
}
