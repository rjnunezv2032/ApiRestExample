using Microsoft.Extensions.Configuration;

namespace Sonda.Core.RemotePrinting.Settings
{
    public static class UsuariosApiSettings
    {
        public static string BaseURL { get; set; }
        public static string UrlApiRol { get; set; }
        public static string UrlApiFuncionalidad { get; set; }
        //public static string UrlApiProcesoNegocio { get; set; }
        //public static string UrlApiArea { get; set; }
        //public static string UrlApiAgencia { get; set; }
        public static string UrlApiUsuarios { get; set; }
        public static string UrlApiUsuario { get; set; }
        public static string UrlApiUsuariosRoles { get; set; }
        public static string UrlApiFuncionalidadesRoles { get; set; }

        public static void SetUpUrlApiSettings(IConfiguration configuration)
        {
            BaseURL = configuration["UrlApi:BaseURL"];
            UrlApiRol = $"{BaseURL}{configuration["UrlApi:Rol"]}";
            UrlApiFuncionalidad = $"{BaseURL}{configuration["UrlApi:Funcionalidad"]}";
            //UrlApiProcesoNegocio = $"{BaseURL}{configuration["UrlApi:ProcesoNegocio"]}";
            //UrlApiArea = $"{BaseURL}{configuration["UrlApi:Area"]}";
            //UrlApiAgencia = $"{BaseURL}{configuration["UrlApi:Agencia"]}";
            UrlApiUsuarios = $"{BaseURL}{configuration["UrlApi:Usuarios"]}";
            UrlApiUsuario = $"{BaseURL}{configuration["UrlApi:Usuario"]}";
            UrlApiUsuariosRoles = $"{BaseURL}{configuration["UrlApi:UsuariosRoles"]}";
            UrlApiFuncionalidadesRoles = $"{BaseURL}{configuration["UrlApi:FuncionalidadesRoles"]}";
        }
    }
}
