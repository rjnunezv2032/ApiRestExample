using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdAgenteIdPrinterStatusKey : IKey
    {

        public int IdAgent {get;set;}
        public int IdPrinter { get; set; }
        public int IdStatus { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdAgent == {0} && IdImpresora== {1} && IdEstado== {2}", IdAgent, IdPrinter, IdStatus));
        }
    }
}
