namespace Sonda.Core.RemotePrinting.Model.Output
{   
    public class PrintJobsOutput
    {
        public virtual int IdImpresora { get; set; }
        public virtual int IdTrabajo { get; set; }
        public virtual int IdEstado { get; set; }

        public virtual string IdUsuario { get; set; }
        public virtual string NombreImpresora { get; set; }
        public virtual int IdEstadoImpresora { get; set; }
        public virtual string DescripcionEstadoImpresora { get; set; }
        public virtual string NombreArchivo { get; set; }
        public virtual byte[] Documento { get; set; }
        public virtual string ConfigImpresion{ get; set; }
        public virtual int PosColaImpresion { get; set; }

        public virtual int IdTipoImpresora { get; set; }

        public virtual int IdTipoDocumento { get; set; }
    }
}
