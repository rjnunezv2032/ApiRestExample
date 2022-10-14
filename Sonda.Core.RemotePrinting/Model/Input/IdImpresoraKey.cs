using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdImpresoraKey : IKey
    {
        public int IdPrinter { get; set; }
        
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdPrinter == {0}", IdPrinter));
        }
    }
}
