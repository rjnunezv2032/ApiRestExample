using Newtonsoft.Json;
using Sonda.Api.Common.Helper.Services;
//using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Settings;
using Sonda.Core.RemotePrinting.Model.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Services
{
    public class WebApiServices : IWebApiServices
    {
        public static string authtoken;

        public void ConfigAuthToken(string value) 
        {
            authtoken = $"Bearer {value}";
        }

        public async Task<List<Rol>> ConsultaRoles()
        {
            var data = new List<Rol>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiRol, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<List<Rol>>>(input.Result);
                if (obj.Result != null) data.AddRange(obj.Result);
            }
            return data;
        }

        public async Task<List<Funcionalidad>> ConsultaFuncionalidades()
        {
            var data = new List<Funcionalidad>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiFuncionalidad, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<List<Funcionalidad>>>(input.Result);
                if (obj.Result != null) data.AddRange(obj.Result);
            }
            return data;
        }

        //public async Task<List<ProcesoNegocio>> ConsultaProcesosNegocios()
        //{
        //    var data = new List<ProcesoNegocio>();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
        //        var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
        //        var message = await client.PostAsync(UsuariosApiSettings.UrlApiProcesoNegocio, formContent);
        //        var input = message.Content.ReadAsStringAsync();
        //        var obj = JsonConvert.DeserializeObject<ServiceResult<List<ProcesoNegocio>>>(input.Result);
        //        if (obj.Result != null) data.AddRange(obj.Result);
        //    }
        //    return data;
        //}

        //public async Task<List<Area>> ConsultaAreas()
        //{
        //    var data = new List<Area>();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
        //        var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
        //        var message = await client.PostAsync(UsuariosApiSettings.UrlApiArea, formContent);
        //        var input = message.Content.ReadAsStringAsync();
        //        var obj = JsonConvert.DeserializeObject<ServiceResult<List<Area>>>(input.Result);
        //        if (obj.Result != null) data.AddRange(obj.Result);
        //    }
        //    return data;
        //}

        //public async Task<List<Agencia>> ConsultaAgencias()
        //{
        //    var data = new List<Agencia>();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
        //        var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
        //        var message = await client.PostAsync(UsuariosApiSettings.UrlApiAgencia, formContent);
        //        var input = message.Content.ReadAsStringAsync();
        //        var obj = JsonConvert.DeserializeObject<ServiceResult<List<Agencia>>>(input.Result);
        //        if (obj.Result != null) data.AddRange(obj.Result);
        //    }
        //    return data;
        //}

        public async Task<List<Usuario>> ConsultarUsuarios()
        {
            var data = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiUsuarios, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<List<Usuario>>>(input.Result);
                if (obj.Result != null) data.AddRange(obj.Result);
            }
            return data;
        }

        public async Task<Usuario> ObtenerUsuario(string idUsuario)
        {
            var data = new Usuario();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, object>() { { "idUsuario", idUsuario } }), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiUsuario, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<Usuario>>(input.Result);
                data = obj.Result;
            }
            return data;
        }

        public async Task<List<UsuarioRol>> ConsultarUsuariosRoles()
        {
            var data = new List<UsuarioRol>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiUsuariosRoles, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<List<UsuarioRol>>>(input.Result);
                if (obj.Result != null) data.AddRange(obj.Result);
            }
            return data;
        }

        public async Task<List<FuncionalidadRol>> ConsultarFuncionalidadesRoles()
        {
            var data = new List<FuncionalidadRol>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authtoken);
                var formContent = new StringContent(JsonConvert.SerializeObject(new QueryOptions()), System.Text.Encoding.UTF8, "application/json");
                var message = await client.PostAsync(UsuariosApiSettings.UrlApiFuncionalidadesRoles, formContent);
                var input = message.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ServiceResult<List<FuncionalidadRol>>>(input.Result);
                if(obj.Result != null) data.AddRange(obj.Result);
            }
            return data;
        }

        //public async Task<RespuestaOutput> EnviaNotificacionSMS(Notificacion entity)
        //{
        //    var data = new RespuestaOutput();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //        var formContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
        //        var message = await client.PostAsync(ComunicacionesApiSettings.UrlNotificacionSMS, formContent);
        //        var input = message.Content.ReadAsStringAsync();
        //        data = JsonConvert.DeserializeObject<RespuestaOutput>(input.Result);
        //    }
        //    return data;
        //}

        //public async Task<RespuestaOutput> EnviaNotificacionWhatsApp(Notificacion entity)
        //{
        //    var data = new RespuestaOutput();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //        var formContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
        //        var message = await client.PostAsync(ComunicacionesApiSettings.UrlNotificacionWhatsApp, formContent);
        //        var input = message.Content.ReadAsStringAsync();
        //        data = JsonConvert.DeserializeObject<RespuestaOutput>(input.Result);
        //    }
        //    return data;
        //}
    }
}
