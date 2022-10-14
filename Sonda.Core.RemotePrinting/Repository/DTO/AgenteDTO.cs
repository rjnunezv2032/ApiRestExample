using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class AgenteDTO : ICamposControl
    {
        public AgenteDTO()
        { }
        public virtual int IdAgente{ get; set; }
        public virtual int IdEstado { get; set; }
        public virtual string CodAgente { get; set; }
        public virtual string DescripcionAgente { get; set; } 
        public virtual string UrlAgente { get; set; }
        public virtual string IpAgente { get; set; }
        public virtual int FrecActualizacion { get; set; }
        public virtual int MaxDataTranfer { get; set; }

        //Campos de auditoria
        public virtual string EstadoReg { get; set; }
        public virtual DateTime? FecEstadoReg { get; set; }
        public virtual DateTime? FecIngReg { get; set; }
        public virtual string IdUsuarioIngReg { get; set; }
        public virtual DateTime? FecUltModifReg { get; set; }
        public virtual string IdUsuarioUltModifReg { get; set; }
        public virtual string IdFuncionUltModifReg { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            AgenteDTO t = obj as AgenteDTO;
            if (t == null) return false;
            if (IdAgente == t.IdAgente) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAgente.GetHashCode();
            return hash;
            //return base.GetHashCode();
        }

    }
}
