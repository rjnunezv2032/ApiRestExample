using Sonda.Core.RemotePrinting.Repository.Base;
using System;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class TrabajosImpresionDTO : ICamposControl
    {
        public virtual int IdTrabajo { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual int IdEstadoImpresion { get; set; }

        public virtual string IdUsuario { get; set; }
        public virtual string DescripcionEstadoImpresora { get; set; }
        public virtual string NombreArchivo { get; set; }
        public virtual byte[] Documento { get; set; }
        public virtual string ConfigImpresion { get; set; }
        public virtual int PosColaImpresion { get; set; }
        public virtual DateTime FechaImpresion { get; set; }

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
            PrintJobsInfoDTO t = obj as PrintJobsInfoDTO;
            if (t == null) return false;
            if (IdTrabajo == t.IdTrabajo && IdImpresora == t.IdImpresora) return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdTrabajo.GetHashCode();
            hash = (hash * 397) ^ IdImpresora.GetHashCode();
            
            return hash;
        }
        #endregion
    }
}
