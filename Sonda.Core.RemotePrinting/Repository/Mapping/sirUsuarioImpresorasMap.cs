using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirUsuarioImpresorasMap : ClassMap<UsuarioImpresorasDTO>
    {
        public sirUsuarioImpresorasMap()
        {
            Table("SIR_USUARIO_IMPRESORAS");
            LazyLoad();

            CompositeId().KeyProperty(x => x.IdAdmin, "ID_ADM")
                         .KeyProperty(x => x.IdImpresora, "ID_IMPRESORA")
                         .KeyProperty(x => x.IdUsuario, "ID_USUARIO");
            Map(x => x.ImpresoraDefault).Column("IMPRESORA_DEFAULT").Not.Nullable();

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
