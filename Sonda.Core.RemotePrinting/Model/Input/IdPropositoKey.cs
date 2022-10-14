using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdPropositoKey : IKey
    {
        public int IdProposito { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdProposito == {0}", IdProposito));
        }
    }
}