namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class PrintJobsInfo
    {
        PrintJobsInfo()
        { }
            
        public virtual int IdTrabajo { get; set; }
        public virtual string NombreArchivo { get; set; }
        public virtual byte Documento { get; set; }
        public virtual string ConfigImpresion { get; set; }
        public virtual int PosColaImpresion { get; set; }
        public virtual int IdAgente { get; set; }
        public virtual string CodAgente { get; set; }
        public virtual string DescripcionAgente { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual string NombreImpresora { get; set; }
        public virtual string DescripcionImpresora { get; set; }
        public virtual string Propiedades { get; set; }
        public virtual string Parametros { get; set; }
        public virtual int IdEstadoImpresora { get; set; }
        public virtual string DescripcionEstadoImpresora { get; set; }
        public virtual int IdProposito { get; set; }
        public virtual string DescripcionProposito { get; set; }
        public virtual int IdTpImpresora { get; set; }
        public virtual string DescripcionTpImpresora { get; set; }
        public virtual int IdEstadoImpresion { get; set; }
        public virtual string DescripcionEstImpresion { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PrintJobsInfo t = obj as PrintJobsInfo;
            if (t == null) return false;
            if (IdImpresora == t.IdImpresora) return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdImpresora.GetHashCode();
            return hash;
        }
    }
}
