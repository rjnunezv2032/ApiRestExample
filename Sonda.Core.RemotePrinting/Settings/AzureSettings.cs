using Microsoft.Extensions.Configuration;

namespace Sonda.Core.RemotePrinting.Settings
{
    public class AzureSettings
    {
        public const string ResourceUrl = "https://graph.windows.net";
        public static string TenantId { get; set; }
        public static string TenantName { get; set; }
        public static string ClientId { get; set; }
        public static string ClientSecret { get; set; }
        public static string AuthString => "https://login.microsoftonline.com/" + TenantName;
        public static void SetUpAzureSettings(IConfiguration configuration)
        {
            TenantId = configuration["AzureAD:TenantId"];
            TenantName = configuration["AzureAD:TenantName"];
            ClientId = configuration["AzureAD:ClientId"];
            ClientSecret = configuration["AzureAD:ClientSecret"];
        }
    }
}
