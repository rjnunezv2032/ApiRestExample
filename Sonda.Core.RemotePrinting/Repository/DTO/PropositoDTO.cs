using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class PropositoDTO : ICamposControl
    {
        public PropositoDTO()
        { }
        public virtual int IdProposito { get; set; }
        public virtual string DescripcionProposito { get; set; }

        //Campos de auditoria
        public virtual string EstadoReg { get; set; }
        public virtual DateTime? FecEstadoReg { get; set; }
        public virtual DateTime? FecIngReg { get; set; }
        public virtual string IdUsuarioIngReg { get; set; }
        public virtual DateTime? FecUltModifReg { get; set; }
        public virtual string IdUsuarioUltModifReg { get; set; }
        public virtual string IdFuncionUltModifReg { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            PropositoDTO t = obj as PropositoDTO;

            if (t == null)
                return false;

            if (IdProposito == t.IdProposito)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdProposito.GetHashCode();
            return hash;
        }
        #endregion

    }
}
