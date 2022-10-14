using Microsoft.Extensions.DependencyInjection;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Api.Controllers.Base
{
    public static class StartupExtension
    {
        /// <summary>
        /// Metodo que se llama cuando inicia la API para registrar las clases que requerirán los controladores mediante inyección de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureControllers(this IServiceCollection services)
        {
            //PDF converter
            services.AddScoped<IGenericRepository<FileOutputDTO, FileInput>, GenericRepository<FileOutputDTO, FileInput>>();
            services.AddScoped<IGenericBO<FileOutput, FileInput>, Business.Base.GenericBO<FileOutput, FileOutputDTO, FileInput>>();
            services.AddScoped<IFileCacheRepository, FileCacheRepository>();
            services.AddScoped<IFileCacheBO, FileCacheBO>();

            //Printers
            services.AddScoped<IGenericRepository<PrinterDTO, IdImpresoraKey>,GenericRepository<PrinterDTO, IdImpresoraKey>>();
            services.AddScoped<IGenericBO<Printer, IdImpresoraKey>, Business.Base.GenericBO<Printer, PrinterDTO, IdImpresoraKey>>();
            services.AddScoped<IPrinterRepository, PrinterRepository>();
            services.AddScoped<IPrinterBO, PrinterBO>();

            //Agentes
            services.AddScoped<IGenericRepository<AgenteDTO, IdAgenteKey>, GenericRepository<AgenteDTO, IdAgenteKey>>();
            services.AddScoped<IGenericBO<Agente, IdAgenteKey>, Business.Base.GenericBO<Agente, AgenteDTO, IdAgenteKey>>();
            services.AddScoped<IAgenteRepository, AgenteRepository>();
            services.AddScoped<IAgenteBO, AgenteBO>();

            //Proposito
            services.AddScoped<IGenericRepository<PropositoDTO, IdPropositoKey>, GenericRepository<PropositoDTO, IdPropositoKey>>();
            services.AddScoped<IGenericBO<Proposito, IdPropositoKey>, Business.Base.GenericBO<Proposito, PropositoDTO, IdPropositoKey>>();
            services.AddScoped<IPropositoRepository, PropositoRepository>();
            services.AddScoped<IPropositoBO, PropositoBO>();

            //Tipo Impresora
            services.AddScoped<IGenericRepository<TipoImpresoraDTO, IdTipoImpresoraKey>, GenericRepository<TipoImpresoraDTO, IdTipoImpresoraKey>>();
            services.AddScoped<IGenericBO<TipoImpresora, IdTipoImpresoraKey>, Business.Base.GenericBO<TipoImpresora, TipoImpresoraDTO, IdTipoImpresoraKey>>();
            services.AddScoped<ITipoImpresoraRepository, TipoImpresoraRepository>();
            services.AddScoped<ITipoImpresoraBO, TipoImpresoraBO>();

            //Tipo Documento
            services.AddScoped<IGenericRepository<TipoDocumentoDTO, IdTipoDocumentoKey>, GenericRepository<TipoDocumentoDTO, IdTipoDocumentoKey>>();
            services.AddScoped<IGenericBO<TipoDocumento, IdTipoDocumentoKey>, Business.Base.GenericBO<TipoDocumento, TipoDocumentoDTO, IdTipoDocumentoKey>>();
            services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddScoped<ITipoDocumentoBO, TipoDocumentoBO>();

            //Estados de Impresion
            services.AddScoped<IGenericRepository<EstadosImpresionDTO, IdEstadoImpresionKey>, GenericRepository<EstadosImpresionDTO, IdEstadoImpresionKey>>();
            services.AddScoped<IGenericBO<EstadosImpresion, IdEstadoImpresionKey>, Business.Base.GenericBO<EstadosImpresion, EstadosImpresionDTO, IdEstadoImpresionKey>>();
            services.AddScoped<IEstadosImpresionRepository, EstadosImpresionRepository>();
            services.AddScoped<IEstadosImpresionBO, EstadosImpresionBO>();

            //Estados de Impresoras
            services.AddScoped<IGenericRepository<EstadosImpresorasDTO, IdEstadoImpresoraKey>, GenericRepository<EstadosImpresorasDTO, IdEstadoImpresoraKey>>();
            services.AddScoped<IGenericBO<EstadosImpresoras, IdEstadoImpresoraKey>, Business.Base.GenericBO<EstadosImpresoras, EstadosImpresorasDTO, IdEstadoImpresoraKey>>();
            services.AddScoped<IEstadosImpresorasRepository, EstadosImpresorasRepository>();
            services.AddScoped<IEstadosImpresorasBO, EstadosImpresorasBO>();

            //Impresoras por usuario
            services.AddScoped<IGenericRepository<PrintersUserInfoDTO, IdUsuarioKey>, GenericRepository<PrintersUserInfoDTO, IdUsuarioKey>>();
            services.AddScoped<IGenericBO<PrintersUserInfo, IdUsuarioKey>, Business.Base.GenericBO<PrintersUserInfo, PrintersUserInfoDTO, IdUsuarioKey>>();
            services.AddScoped<IPrintersUserInfoRepository, PrintersUserInfoRepository>();
            services.AddScoped<IPrintersUserInfoBO, PrintersUserInfoBO>();

            //Impresoras por Agente
            services.AddScoped<IGenericRepository<PrintingAgentsInfoDTO, IdAgenteKey>, GenericRepository<PrintingAgentsInfoDTO, IdAgenteKey>>();
            services.AddScoped<IGenericBO<PrintersAgentInfo, IdAgenteKey>, Business.Base.GenericBO<PrintersAgentInfo, PrintingAgentsInfoDTO, IdAgenteKey>>();
            services.AddScoped<IPrintersAgentInfoRepository, PrintersAgentInfoRepository>();
            services.AddScoped<IPrintersAgentInfoBO, PrintersAgentInfoBO>();

            //Informacion del estado de los Trabajos de Impresion por usuario
            services.AddScoped<IGenericRepository<PrintJobsInfoDTO, IdUsuarioKey>, GenericRepository<PrintJobsInfoDTO, IdUsuarioKey>>();
            services.AddScoped<IGenericBO<PrintJobsInfo, IdUsuarioKey>, Business.Base.GenericBO<PrintJobsInfo, PrintJobsInfoDTO, IdUsuarioKey>>();
            services.AddScoped<IPrintJobsInfoRepository, PrintJobsInfoRepository>();
            services.AddScoped<IPrintJobsInfoBO, PrintJobsInfoBO>();

            //Trabajos de Impresion
            services.AddScoped<IGenericRepository<TrabajosImpresionDTO, CodAgenteIpImpresoraKey>, GenericRepository<TrabajosImpresionDTO, CodAgenteIpImpresoraKey>>();
            services.AddScoped<IGenericBO<TrabajosImpresion, CodAgenteIpImpresoraKey>, Business.Base.GenericBO<TrabajosImpresion, TrabajosImpresionDTO, CodAgenteIpImpresoraKey>>();
            services.AddScoped<IPrintJobsRepository, PrintJobsRepository>();
            services.AddScoped<IPrintJobsBO, PrintJobsBO>();

            //RegistryPrintUsersBO
            services.AddScoped<IGenericRepository<UsuarioImpresorasDTO, IdKey>, GenericRepository<UsuarioImpresorasDTO, IdKey>>();
            services.AddScoped<IGenericBO<UsuarioImpresoras, IdKey>, Business.Base.GenericBO<UsuarioImpresoras, UsuarioImpresorasDTO, IdKey>>();
            services.AddScoped<IRegistryPrintsUserRepository, RegistryPrintsUserRepository>();
            services.AddScoped<IRegistryPrintUsersBO, RegistryPrintUsersBO>();

            ////Services
            //services.AddScoped<Services.IEmailService, Services.SMTPEmailService>();
            services.AddScoped<Services.IWebApiServices, Services.WebApiServices>();
        }
    }
}
