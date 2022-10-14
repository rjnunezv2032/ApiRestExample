using Sonda.Core.RemotePrinting.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class PrinterDTO : ICamposControl
    {

        public virtual int IdPrinter { get; set; }
        public virtual int IdAgent { get; set; }
        public virtual int IdEstado { get; set; }
        public virtual int IdTipoDocumento { get; set; }
        public virtual int IdTipoImpresora { get; set; }
        public virtual int IdPurpose { get; set; }

        public virtual string PrinterName { get; set; }
        public virtual string Description { get; set; }
        public virtual string IpLocation { get; set; }
        public virtual string PrinterProperties { get; set; }
        public virtual string Parameters { get; set; }


        //Estos atributos se heredan de la interfaz ICamposControl
        public virtual string EstadoReg { get; set; }
        public virtual DateTime? FecEstadoReg { get; set; }
        public virtual DateTime? FecIngReg { get; set; }
        public virtual string IdUsuarioIngReg { get; set; }
        public virtual DateTime? FecUltModifReg { get; set; }
        public virtual string IdUsuarioUltModifReg { get; set; }
        public virtual string IdFuncionUltModifReg { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PrinterDTO t = obj as PrinterDTO;
            if (t == null) return false;
            if (IdPrinter == t.IdPrinter && IdAgent == t.IdAgent) return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdPrinter.GetHashCode();
            hash = (hash * 397) ^ IdAgent.GetHashCode();
            return hash;
            //return base.GetHashCode();
        }
        #endregion

    }
}
