using FluentNHibernate.Mapping;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository.Mapping
{
    public class sirAgenteMap : ClassMap<AgenteDTO>
    {
        public sirAgenteMap()
        {
            Table("SIR_AGENTE");

            LazyLoad();

            Id(x => x.IdAgente).GeneratedBy.Assigned().Column("ID_AGENTE");
            Map(x => x.IdEstado).Column("ID_ESTADO").Not.Nullable(); 
            Map(x => x.CodAgente).Column("COD_AGENTE").Not.Nullable();
            Map(x => x.DescripcionAgente).Column("DESCRIPCION_AGENTE").Not.Nullable();
            Map(x => x.UrlAgente).Column("URL_AGENTE").Not.Nullable();
            Map(x => x.IpAgente).Column("IP_AGENTE").Not.Nullable();
            Map(x => x.FrecActualizacion).Column("FREC_ACTUALIZACION").Not.Nullable(); ;
            Map(x => x.MaxDataTranfer).Column("MAX_DATA_TRANSFER").Not.Nullable(); ;
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
