using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdTipoImpresoraKey : IKey
    {
        public int IdTpImpresora { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdTpImpresora == {0}", IdTpImpresora));
        }
    }
}