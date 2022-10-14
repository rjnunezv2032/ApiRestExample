using System;

namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class StatusMensajeDetalleOutput
    {
        public string EnvioId { get; set; }
        public string Canal { get; set; }
        public string Proceso { get; set; }
        public string Etapa { get; set; }
        public string Regla { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Usuario { get; set; }
        public string ErrorURL { get; set; }
        public string ErrorEnvio { get; set; }
    }
}
