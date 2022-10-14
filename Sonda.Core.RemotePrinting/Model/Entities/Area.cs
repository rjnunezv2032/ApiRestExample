using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Area
    {
        public Area() { }
        public virtual short IdAdm { get; set; }
        public virtual short CodArea { get; set; }
        public virtual string Descripcion { get; set; }
        //public virtual string EstadoReg { get; set; }
        //public virtual DateTime FecEstadoReg { get; set; }
        //public virtual DateTime FecIngReg { get; set; }
        //public virtual string IdUsuarioIngReg { get; set; }
        //public virtual DateTime FecUltModifReg { get; set; }
        //public virtual string IdUsuarioUltModifReg { get; set; }
        //public virtual string IdFuncionUltModifReg { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Area t = obj as Area;
            if (t == null) return false;
            if (IdAdm == t.IdAdm
             && CodArea == t.CodArea)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdm.GetHashCode();
            hash = (hash * 397) ^ CodArea.GetHashCode();

            return hash;
        }
        #endregion
    }
}
