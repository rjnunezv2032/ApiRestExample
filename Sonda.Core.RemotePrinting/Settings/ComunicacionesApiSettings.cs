using Microsoft.Extensions.Configuration;

namespace Sonda.Core.RemotePrinting.Settings
{
    public class ComunicacionesApiSettings
    {
        public static string BaseURL { get; set; }
        public static string UrlNotificacionSMS { get; set; }
        public static string UrlNotificacionWhatsApp { get; set; }

        public static void Config(IConfiguration configuration)
        {
            BaseURL = configuration["ComunicacionesApi:BaseURL"];
            UrlNotificacionSMS = $"{BaseURL}{configuration["ComunicacionesApi:NotificacionSMS"]}";
            UrlNotificacionWhatsApp = $"{BaseURL}{configuration["ComunicacionesApi:NotificacionWhatsApp"]}";
        }
    }
}
