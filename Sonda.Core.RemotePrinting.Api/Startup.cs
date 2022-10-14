using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sonda.Core.RemotePrinting.Api.Controllers.Base;
using Sonda.Core.RemotePrinting.Business.Mapper;
using Sonda.Api.Common.Login;
using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Linq;
using Sonda.Core.Cryptography;

namespace Sonda.Core.RemotePrinting.Api
{
    public class Startup : SondaBaseStartup
    {
        protected IWebHostEnvironment CurrentEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration)
        {
            CurrentEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSondaCore(Configuration);
            #region "Lógica de negocios y repositorios"
            services.ConfigureControllers();
            #endregion
            #region Automapper
            services.AddAutoMapper(typeof(RemotePrintingMapper));
            #endregion Automapper

            services.AddMediatR(typeof(RemotePrintingMapper).Assembly);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
            });

            #region Static Settings
            Settings.ApplicationSettings.SetUpApplicationSettings(Configuration);
            Settings.AzureSettings.SetUpAzureSettings(Configuration);
            Settings.ConstantSettings.SetUpConstantSettings(Configuration);
            Settings.UsuariosApiSettings.SetUpUrlApiSettings(Configuration);
            Settings.ComunicacionesApiSettings.Config(Configuration);
            RSAKeySettings.ConfigPublicKey(Configuration, CurrentEnvironment.ContentRootPath);
            #endregion Static Settings

            //services.AddSignalR();

            services.AddCors(options =>
            {
                var corsUrls = Configuration.GetSection("App:CorsOrigins").Value.ToString()
                          .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(o => o.Trim('/'))
                                 .ToArray();
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins(corsUrls)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets(new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120)});
            app.UseCors("CorsPolicy");
            app.UseSondaCore();
        }
    }    
}
