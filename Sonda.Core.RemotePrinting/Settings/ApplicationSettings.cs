using Microsoft.Extensions.Configuration;

namespace Sonda.Core.RemotePrinting.Settings
{
    public static class ApplicationSettings
    {
        public static string ResetPasswordURL { get; set; }
        public static string APIMETHOD { get; set; }
        public static string CTRLDES { get;set; }
        public static void SetUpApplicationSettings(IConfiguration configuration)
        {
            ResetPasswordURL = configuration["Application:ResetPasswordURL"];
            APIMETHOD = configuration["Application:ServicePath"];
            CTRLDES = configuration["Application:ControlPath"];
        }
        
    }
}
