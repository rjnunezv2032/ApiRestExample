using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class UsuarioImpresorasDTO : ICamposControl
    {
        public UsuarioImpresorasDTO()
        { }

        public virtual int IdAdmin { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual string IdUsuario{ get; set; }
        public virtual bool? ImpresoraDefault { get; set; }

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
            if (obj == null) return false;
            UsuarioImpresorasDTO t = obj as UsuarioImpresorasDTO;
            if (t == null) return false;
            if (IdAdmin == t.IdAdmin && IdImpresora == t.IdImpresora && IdUsuario == t.IdUsuario) return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdmin.GetHashCode();
            hash = (hash * 397) ^ IdImpresora.GetHashCode();
            hash = (hash * 397) ^ IdUsuario.GetHashCode();
            return hash;
        }
        #endregion

    }
}
