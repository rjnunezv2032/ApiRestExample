using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Threading.Tasks;


namespace Sonda.Core.RemotePrinting.Business
{
    public interface IAgenteBO : IGenericBO<Agente, IdAgenteKey>
    {
        Task RemovePrinter(IdAgenteKey filtro);
    }
}
