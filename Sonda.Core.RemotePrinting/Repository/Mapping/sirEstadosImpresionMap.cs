using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirEstadosImpresionMap : ClassMap<EstadosImpresionDTO>
    {
        public sirEstadosImpresionMap()
        {
            Table("SIR_ESTADOS_IMPRESION");
            LazyLoad();

            Id(x => x.IdEstadoImpresion).GeneratedBy.Assigned().Column("ID_ESTADO_IMPRESION");
            Map(x => x.DescripcionEstImp).Column("DESCRIPCION_EST_IMP");

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
