using System;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class TrabajosImpresion
    {
        public virtual int IdImpresora { get; set; }
        public virtual int IdTrabajo { get; set; }
        public virtual int IdEstadoImpresion { get; set; }
        public virtual string IdUsuario { get; set; }
        public virtual string NombreArchivo { get; set; }
        public virtual byte[] Documento { get; set; }
        public virtual string ConfigImpresion { get; set; }
        public virtual int PosColaImpresion { get; set; }
        public virtual DateTime FechaImpresion { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TrabajosImpresion t = obj as TrabajosImpresion;
            if (t == null) return false;
            if (IdImpresora == t.IdImpresora && IdTrabajo == t.IdTrabajo) return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdImpresora.GetHashCode();
            hash = (hash * 397) ^ IdTrabajo.GetHashCode();
            return hash;
        }
    }
}
