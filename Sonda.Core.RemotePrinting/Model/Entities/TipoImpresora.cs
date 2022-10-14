using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class TipoImpresora
    {
        public TipoImpresora(){ }

        public virtual int IdTpImpresora { get; set; }
        public virtual string DescripcionTpImpresora { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            TipoImpresora t = obj as TipoImpresora;

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
