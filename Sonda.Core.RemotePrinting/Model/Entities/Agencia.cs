using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Agencia
    {
        public Agencia() { }
        public virtual short IdAdm { get; set; }
        public virtual short CodAgencia { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Direccion { get; set; }
        public virtual int CodComuna { get; set; }
        public virtual int Folioreclamo650 { get; set; }
        public virtual short CodSubgerencia { get; set; }
        public virtual string HorarioAtencion { get; set; }
        public virtual int? CodZona { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Agencia t = obj as Agencia;
            if (t == null) return false;
            if (IdAdm == t.IdAdm
             && CodAgencia == t.CodAgencia)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdm.GetHashCode();
            hash = (hash * 397) ^ CodAgencia.GetHashCode();

            return hash;
        }
        #endregion
    }
}
