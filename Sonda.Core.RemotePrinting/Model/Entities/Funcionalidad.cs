using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Funcionalidad
    {
        public Funcionalidad() { }
        public virtual string IdFuncionalidad { get; set; }
        public virtual string IdProcesoNegocio { get; set; }
        //  public virtual ProcesoNegocio Procesosnegocio { get; set; }
        public virtual string Descripcion { get; set; }
        //public virtual string EstadoReg { get; set; }
        //public virtual DateTime? FecEstadoReg { get; set; }
        //public virtual DateTime? FecIngReg { get; set; }
        //public virtual string IdUsuarioIngReg { get; set; }
        //public virtual DateTime? FecUltModifReg { get; set; }
        //public virtual string IdUsuarioUltModifReg { get; set; }
        //public virtual string IdFuncionUltModifReg { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Funcionalidad t = obj as Funcionalidad;
            if (t == null) return false;
            if (IdFuncionalidad == t.IdFuncionalidad) return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdFuncionalidad.GetHashCode();
            return hash;
        }
        #endregion

    }
}
