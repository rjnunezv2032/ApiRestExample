using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirImpresoraMap : ClassMap<PrinterDTO>
    {
        public sirImpresoraMap()
        {
            Table("SIR_IMPRESORA");
            LazyLoad();

            Id(x => x.IdPrinter).GeneratedBy.Assigned().Column("ID_IMPRESORA");
            Map(x => x.IdAgent).Column("ID_AGENTE").Not.Nullable();
            Map(x => x.IdPurpose).Column("ID_PROPOSITO");
            Map(x => x.PrinterName).Column("NOMBRE_IMPRESORA").Not.Nullable();
            Map(x => x.Description).Column("DESCRIPCION_IMPRESORA");
            Map(x => x.IpLocation).Column("IP_UBICACION");            
            Map(x => x.IdTipoImpresora).Column("ID_TP_IMPRESORA");
            Map(x => x.PrinterProperties).Column("PROPIEDADES");
            Map(x => x.Parameters).Column("PARAMETROS");
            Map(x => x.IdEstado).Column("ID_ESTADO");
            Map(x => x.IdTipoDocumento).Column("ID_TIPO_DOC")
                ;
            Map(x => x.EstadoReg).Column("ESTADO_REG");
            Map(x => x.FecEstadoReg).Column("FEC_ESTADO_REG");
            Map(x => x.FecIngReg).Column("FEC_ING_REG");
            Map(x => x.IdUsuarioIngReg).Column("ID_USUARIO_ING_REG");
            Map(x => x.FecUltModifReg).Column("FEC_ULT_MODIF_REG");
            Map(x => x.IdUsuarioUltModifReg).Column("ID_USUARIO_ULT_MODIF_REG");
            Map(x => x.IdFuncionUltModifReg).Column("ID_FUNCION_ULT_MODIF_REG");
        }
    }


}
