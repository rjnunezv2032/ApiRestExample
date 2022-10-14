using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IRegistryPrintsUserRepository : IGenericRepository<UsuarioImpresorasDTO,IdKey>
    {
        //Task SetRegistryPrintAgents(List<Printer> impresoras, string IdUsuario, int IdAdmin, bool impresoraDefault);
        Task UpdatePrintUser(IdAdmIdUsuarioIdImpresoraKey impresorasUsuario);

        Task SetRegistryPrintUsers(List<IdAdmIdUsuarioIdImpresoraKey> impresorasUsuario);
    }
}
