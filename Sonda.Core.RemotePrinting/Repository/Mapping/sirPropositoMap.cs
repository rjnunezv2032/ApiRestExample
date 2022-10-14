using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirPropositoMap : ClassMap<PropositoDTO>
    {
        public sirPropositoMap()
        {
            Table("SIR_PROPOSITO");
            LazyLoad();

            Id(x => x.IdProposito).GeneratedBy.Assigned().Column("ID_PROPOSITO"); 
            Map(x => x.DescripcionProposito).Column("DESCRIPCION_PROPOSITO").Not.Nullable();

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
