using Microsoft.Extensions.Configuration;
using System;

namespace Sonda.Core.RemotePrinting.Settings
{
    public static class ConstantSettings
    {
        public static string CanalWhatsApp { get; set; }
        public static string CanalSMS { get; set; }
        public static string CanalEmail { get; set; }
        public static string CanalAplicacion { get; set; }

        public static string CriterioRol { get; set; }
        public static string CriterioFuncionalidad { get; set; }
        public static string CriterioProcesoNegocio { get; set; }
        public static string CriterioRegion { get; set; }
        public static string CriterioPais { get; set; }
        public static string CriterioArea { get; set; }
        public static string CriterioAgencia { get; set; }

        public static string EstadoMensajePendiente { get; set; }
        public static string EstadoMensajeEnviado { get; set; }
        public static string EstadoMensajeEntregado { get; set; }
        public static string EstadoMensajeLeido { get; set; }
        public static string EstadoMensajeConError { get; set; }

        public static string AtributoTexto { get; set; }
        public static string AtributoImagen { get; set; }
        public static string AtributoDocumento { get; set; }
        public static string AtributoURL { get; set; }

        public static int ImagenMaximoTamaño { get; set; }
        public static string ImagenExtensionesPermitidas { get; set; }
        public static int DocumentoMaximoTamaño { get; set; }
        public static string DocumentoExtensionesPermitidas { get; set; }

        public static string UrlErrorCodes { get; set; }

        public static int MaximoHorasVisualizacionLeidos { get; set; }
        public static int TotalMensajesBandeja { get; set; }

        public static bool EliminarFisicamente { get; set; }

        public static int BufferSize { get; set; }

        public static void SetUpConstantSettings(IConfiguration configuration)
        {
            BufferSize = Convert.ToInt32(configuration["RemotePrinting:BufferSize"]);
            EliminarFisicamente = Convert.ToBoolean(configuration["RemotePrinting:EliminarFisicamente"]);

            CanalWhatsApp = configuration["Canal:WhatsApp"];
            CanalSMS = configuration["Canal:SMS"];
            CanalEmail = configuration["Canal:Email"];
            CanalAplicacion = configuration["Canal:Aplicacion"];

            CriterioRol = configuration["Criterio:Rol"];
            CriterioFuncionalidad = configuration["Criterio:Funcionalidad"];
            CriterioProcesoNegocio = configuration["Criterio:ProcesoNegocio"];
            CriterioRegion = configuration["Criterio:Region"];
            CriterioPais = configuration["Criterio:Pais"];
            CriterioArea = configuration["Criterio:Area"];
            CriterioAgencia = configuration["Criterio:Agencia"];

            EstadoMensajePendiente = configuration["EstadoMensaje:Pendiente"];
            EstadoMensajeEnviado = configuration["EstadoMensaje:Enviado"];
            EstadoMensajeEntregado = configuration["EstadoMensaje:Entregado"];
            EstadoMensajeLeido = configuration["EstadoMensaje:Leido"];
            EstadoMensajeConError = configuration["EstadoMensaje:ConError"];

            AtributoTexto = configuration["Atributo:Texto"];
            AtributoImagen = configuration["Atributo:Imagen"];
            AtributoDocumento = configuration["Atributo:Documento"];
            AtributoURL = configuration["Atributo:URL"];

            ImagenMaximoTamaño = Convert.ToInt32(configuration["Archivo:Imagen:MaximoTamanio"]);
            ImagenExtensionesPermitidas = configuration["Archivo:Imagen:ExtensionesPermitidas"];
            DocumentoMaximoTamaño = Convert.ToInt32(configuration["Archivo:Documento:MaximoTamanio"]);
            DocumentoExtensionesPermitidas = configuration["Archivo:Documento:ExtensionesPermitidas"];

            UrlErrorCodes = configuration["Twilio:ErrorCodesURL"];

            MaximoHorasVisualizacionLeidos = Convert.ToInt32(configuration["Notificacion:MaximoHorasVisualizacionLeidos"]);
            TotalMensajesBandeja = Convert.ToInt32(configuration["Notificacion:TotalMensajesBandeja"]);
        }
    }
}
