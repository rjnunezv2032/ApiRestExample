using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirTrabajosImpresionMap : ClassMap<TrabajosImpresionDTO>
    {
        public sirTrabajosImpresionMap()
        {
            Table("SIR_TRABAJOS_IMPRESION");
            LazyLoad();

            //CompositeId().KeyProperty(x => x.IdTrabajo, "ID_TRABAJO")
            //             .KeyProperty(x => x.IdImpresora, "ID_IMPRESORA");
            Id(x => x.IdTrabajo).GeneratedBy.Assigned().Column("ID_TRABAJO");
            Map(x => x.IdImpresora, "ID_IMPRESORA");
            Map(x => x.IdEstadoImpresion).Column("ID_ESTADO_IMPRESION").Not.Nullable();
            Map(x => x.IdUsuario).Column("ID_USUARIO");

            Map(x => x.PosColaImpresion).Column("POS_COLA_IMPRESION");
            Map(x => x.Documento).Column("DOCUMENTO").Length(int.MaxValue);
            Map(x => x.NombreArchivo).Column("NOMBRE_ARCHIVO");
            Map(x => x.ConfigImpresion).Column("CONFIG_IMPRESION");
            Map(x => x.FechaImpresion).Column("FECHA_IMPRESION");

            Map(x => x.EstadoReg).Column("ESTADO_REG");
            Map(x => x.FecEstadoReg).Column("FEC_ESTADO_REG");
            Map(x => x.FecIngReg).Column("FEC_ING_REG");
            Map(x => x.IdUsuarioIngReg).Column("ID_USUARIO_ING_REG");
            Map(x => x.FecUltModifReg).Column("FEC_ULT_MODIF_REG");
            Map(x => x.IdUsuarioUltModifReg).Column("ID_USUARIO_ULT_MODIF_REG");
            Map(x => x.IdFuncionUltModifReg).Column("ID_FUNCION_ULT_MODIF_REG");

            //References(x => x.IdImpresora).Column("ID_IMPRESORA");
            //References(x => x.IdEstadoImpresion).Column("ID_ESTADO_IMPRESION");
        }
    }


}
