using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class CodAgenteIpImpresoraKey : IKey
    {
        public string CodAgente { get; set; }
        public string IpAgente { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("CodAgente == {0} && IdImpresora == {2}", CodAgente, IpAgente));
        }
    }
}
