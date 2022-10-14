//using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Services
{
    public interface IWebApiServices
    {
        void ConfigAuthToken(string value);

        Task<List<Rol>> ConsultaRoles();

        Task<List<Funcionalidad>> ConsultaFuncionalidades();       

        //Task<List<Area>> ConsultaAreas();

        //Task<List<Agencia>> ConsultaAgencias();

        Task<List<Usuario>> ConsultarUsuarios();

        Task<Usuario> ObtenerUsuario(string idUsuario);

        Task<List<UsuarioRol>> ConsultarUsuariosRoles();

        Task<List<FuncionalidadRol>> ConsultarFuncionalidadesRoles();

              
    }
}
