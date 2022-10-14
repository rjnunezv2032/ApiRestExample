namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class StatusMensajeResumenOutput
    {
        public string CodigoCanal { get; set; }
        public string NombreCanal { get; set; }
        public int Enviados { get; set; }
        public int Pendientes { get; set; }
        public int Entregados { get; set; }
        public int ConError { get; set; }
        public int Leidos { get; set; }
    }
}
