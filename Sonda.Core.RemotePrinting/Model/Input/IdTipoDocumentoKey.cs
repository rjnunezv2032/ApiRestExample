using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdTipoDocumentoKey : IKey
    {
        public int IdTipoDoc { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdTipoDoc == {0}", IdTipoDoc));
        }
    }
}