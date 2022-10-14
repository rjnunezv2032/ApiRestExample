using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class PDF_File
    {
        public PDF_File()
        { }

        public virtual int IdFile { get; set; }
        public virtual byte[] Document { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PDF_File t = obj as PDF_File;
            if (t == null) return false;
            if (IdFile == t.IdFile) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdFile.GetHashCode();
            return hash;
        }
        #endregion

    }
}
