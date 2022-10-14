using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonda.Core.RemotePrinting.Model;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Repository.DTO;


namespace Sonda.Core.RemotePrinting.Business.Mapper
{
    public class RemotePrintingMapper:Profile
    {
        public RemotePrintingMapper()
        {
            CreateMap<FileOutput, FileOutputDTO>();
            CreateMap<FileOutputDTO, FileOutput>();

            CreateMap<Agente, AgenteDTO>();
            CreateMap<AgenteDTO, Agente>();

            CreateMap<EstadosImpresoras, EstadosImpresorasDTO>();
            CreateMap<EstadosImpresorasDTO, EstadosImpresoras>();

            CreateMap<EstadosImpresion, EstadosImpresionDTO>();
            CreateMap<EstadosImpresionDTO, EstadosImpresion>();

            CreateMap<Printer, PrinterDTO>();
            CreateMap<PrinterDTO, Printer>();

            CreateMap<Proposito, PropositoDTO>();
            CreateMap<PropositoDTO, Proposito>();

            CreateMap<TipoImpresora, TipoImpresoraDTO>();
            CreateMap<TipoImpresoraDTO, TipoImpresora>();

            CreateMap<TipoDocumento, TipoDocumentoDTO>();
            CreateMap<TipoDocumentoDTO, TipoDocumento>();

            CreateMap<UsuarioImpresoras, UsuarioImpresorasDTO>();
            CreateMap<UsuarioImpresorasDTO, UsuarioImpresoras>();

            //Mapeo de OUTPUT
            //Mapeo de impresoras por Agente
            CreateMap<PrintersAgentInfo, PrintingAgentsInfoDTO>();
            CreateMap<PrintingAgentsInfoDTO, PrintersAgentInfo>();

            //Mapeo de Impresoras por Usuarios
            CreateMap<PrintersUserInfo, PrintersUserInfoDTO>();
            CreateMap<PrintersUserInfoDTO, PrintersUserInfo>();

            //Mapeo de Informacion de trabajos de impresion
            CreateMap<PrintJobsInfo, PrintJobsInfoDTO>();
            CreateMap<PrintJobsInfoDTO, PrintJobsInfo>();

            //Mapeo de trabajos de impresion
            CreateMap<TrabajosImpresion, TrabajosImpresionDTO>();
            CreateMap<TrabajosImpresionDTO, TrabajosImpresion>();
        }        
    }
}
