using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirEstadoImpresorasMap : ClassMap<EstadosImpresorasDTO>
    {
        public sirEstadoImpresorasMap()
        {
            Table("SIR_ESTADO_IMPRESORAS");
            LazyLoad();

            Id(x => x.IdEstado).GeneratedBy.Assigned().Column("ID_ESTADO");

            //Id(x => x.IdEstado).GeneratedBy.Increment().Column("ID_ESTADO");

            Map(x => x.DescripcionEstado).Column("DESCRIPCION_ESTADO").Not.Nullable();

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
