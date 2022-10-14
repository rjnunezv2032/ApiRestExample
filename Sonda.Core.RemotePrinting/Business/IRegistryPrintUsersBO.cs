using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{
    public interface IRegistryPrintUsersBO : IGenericBO<UsuarioImpresoras,IdKey>
    {
        Task UpdatePrintUser(IdAdmIdUsuarioIdImpresoraKey impresorasUsuario);
        Task SetRegistryPrintUsers(List<IdAdmIdUsuarioIdImpresoraKey> impresorasUsuario);
    }
}
