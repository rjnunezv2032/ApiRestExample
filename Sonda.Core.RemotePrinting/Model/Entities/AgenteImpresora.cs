using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class AgenteImpresora
    {
        public AgenteImpresora()
        { }
        public virtual int IdAgente{ get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual int IdEstado { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            AgenteImpresora t = obj as AgenteImpresora;
            if (t == null) return false;
            if (IdAgente == t.IdAgente && IdImpresora == t.IdImpresora) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAgente.GetHashCode();
            hash = (hash * 397) ^ IdImpresora.GetHashCode();
            return hash;
        }
        #endregion

    }
}
