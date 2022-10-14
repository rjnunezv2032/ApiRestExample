using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class UsuarioImpresoras
    {
        public UsuarioImpresoras()
        { }

        public virtual int IdAdmin { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual string IdUsuario{ get; set; }
        public virtual bool ImpresoraDefault { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            UsuarioImpresoras t = obj as UsuarioImpresoras;
            if (t == null) return false;
            if (IdAdmin == t.IdAdmin && IdImpresora == t.IdImpresora  && IdUsuario == t.IdUsuario) return true;
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
