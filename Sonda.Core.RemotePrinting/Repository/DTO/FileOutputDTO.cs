using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class FileOutputDTO //: ICamposControl
    {
        public FileOutputDTO()
        { }

        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int NumberOfPages { get; set; }
        public byte[] DocumentBase64 { get; set; }
        

 
        ////Campos de auditoria
        //public virtual string EstadoReg { get; set; }
        //public virtual DateTime? FecEstadoReg { get; set; }
        //public virtual DateTime? FecIngReg { get; set; }
        //public virtual string IdUsuarioIngReg { get; set; }
        //public virtual DateTime? FecUltModifReg { get; set; }
        //public virtual string IdUsuarioUltModifReg { get; set; }
        //public virtual string IdFuncionUltModifReg { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FileOutputDTO t = obj as FileOutputDTO;
            if (t == null) return false;
            if (Id == t.Id) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Id.GetHashCode();
            return hash;
            //return base.GetHashCode();
        }

    }
}
