namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class RespuestaOutput
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public object Elemento { get; set; }
        public bool EsError { get; set; }
    }
}
