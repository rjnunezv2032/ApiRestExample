using System;
using System.Collections.Generic;
using System.Text;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Rol
    {
        public Rol() { }
        public virtual short IdAdm { get; set; }
        public virtual string IdRol { get; set; }
        //public virtual ProcesoNegocio ProcesoNegocio { get; set; }
        public virtual string IdProcesoNegocio { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string IndAdminPn { get; set; }
        public virtual string TipoRolWorkflow { get; set; }

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
            Rol t = obj as Rol;
            if (t == null) return false;
            if (IdAdm == t.IdAdm
             && IdRol == t.IdRol)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdm.GetHashCode();
            hash = (hash * 397) ^ IdRol.GetHashCode();

            return hash;
        }
        #endregion
    }
}
