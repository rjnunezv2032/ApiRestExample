using System;

namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class MensajeUsuarioOutput
    {
        public short IdAdm { get; set; }
        public string IdUsuario { get; set; }
        public long MensajeId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string TituloMensaje { get; set; }
        public string DescripcionCortaMensaje { get; set; }
        public string DescripcionMensaje { get; set; }
        public string UrlMensaje { get; set; }
        public string DatosNegocio { get; set; }
        public bool Leido { get; set; }
        public string ImagenNombre { get; set; }
        public string ImagenData { get; set; }
        public string DocumentoNombre { get; set; }
        public string DocumentoData { get; set; }
        public bool DiaActual { get; set; }
        public bool Seleccionado { get; set; }
        public bool Descartado { get; set; }
    }
}
