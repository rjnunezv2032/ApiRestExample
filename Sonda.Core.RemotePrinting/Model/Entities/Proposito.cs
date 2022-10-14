using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Proposito
    {
        public Proposito(){ }

        public virtual int IdProposito { get; set; }
        public virtual string DescripcionProposito { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            Proposito t = obj as Proposito;

            if (t == null) 
                return false;

            if (IdProposito == t.IdProposito)
                return true;

            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdProposito.GetHashCode();
            return hash;
        }
        #endregion

    }
}
