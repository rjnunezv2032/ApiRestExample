using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdAgenteKey : IKey
    {
        public int IdAgente { get; set; }
        public int IdImpresora { get; set; }

        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdAgente == {0} && IdImpresora == {1}", IdAgente, IdImpresora));
        }
    }
}