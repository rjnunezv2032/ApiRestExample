using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class EstadosImpresion
    {
        public EstadosImpresion()
        { }

        public virtual int IdEstadoImpresion { get; set; }
        public virtual string DescripcionEstImp { get; set; }
        public virtual string EstadoReg { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            EstadosImpresion t = obj as EstadosImpresion;
            if (t == null) return false;
            if (IdEstadoImpresion == t.IdEstadoImpresion) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdEstadoImpresion.GetHashCode();
            return hash;
        }
        #endregion

    }
    public enum eEstImp
    {
        pendiente = 1,
	    imprimiendo = 2,
	    pausado = 3,
	    finalizado = 4,
	    cancelado = 5
    }
}
