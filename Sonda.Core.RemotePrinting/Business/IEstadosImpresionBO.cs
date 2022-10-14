using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sonda.Core.RemotePrinting.Business
{
    public interface IEstadosImpresionBO : IGenericBO<EstadosImpresion, IdEstadoImpresionKey>
    {
        Task<IEnumerable<EstadosImpresion>> GetAll();
    }
}
