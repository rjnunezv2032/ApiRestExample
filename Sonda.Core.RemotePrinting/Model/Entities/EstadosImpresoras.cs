using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class EstadosImpresoras
    {
        public EstadosImpresoras()
        { }

        public virtual int IdEstado { get; set; }
        public virtual string DescripcionEstado { get; set; }
        public virtual string EstadoReg { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            EstadosImpresoras t = obj as EstadosImpresoras;
            if (t == null) return false;
            if (IdEstado == t.IdEstado) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdEstado.GetHashCode();
            return hash;
        }
        #endregion

    }
}
