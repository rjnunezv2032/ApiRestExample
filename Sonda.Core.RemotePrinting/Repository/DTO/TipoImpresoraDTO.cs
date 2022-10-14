using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class TipoImpresoraDTO : ICamposControl
    {
        public TipoImpresoraDTO()
        { }
        public virtual int IdTpImpresora { get; set; }
        public virtual string DescripcionTpImpresora { get; set; }

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

            TipoImpresoraDTO t = obj as TipoImpresoraDTO;

            if (t == null)
                return false;

            if (IdTpImpresora == t.IdTpImpresora)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdTpImpresora.GetHashCode();
            return hash;
        }
        #endregion

    }
}
