namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class PrintersUserInfoOutput
    {
        public virtual string IdUsuario { get; set; }
        public virtual int IdAdm { get; set; }
        public virtual int IdAgente { get; set; }
        public virtual string CodAgente { get; set; }
        public virtual string DescripcionAgente { get; set; }
        public virtual int MaxDataTranfer { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual string NombreImpresora { get; set; }
        public virtual string DescripcionImpresora { get; set; }
        public virtual bool? ImpresoraDefault { get; set; }
        public virtual string Propiedades { get; set; }
        public virtual string Parametros { get; set; }
        public virtual int IdProposito { get; set; }
        public virtual string DescripcionProposito { get; set; }
        public virtual int IdTpImpresora { get; set; }
        public virtual string DescripcionTpImpresora { get; set; }
        public virtual int IdEstadoImpresora { get; set; }
        public virtual string DescripcionEstadoImpresora { get; set; }
        public virtual int IdTipoDoc { get; set; }
        public virtual string DescTipoDoc { get; set; }
        
    }
}
