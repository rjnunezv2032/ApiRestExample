using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdPrinterIdAgentKey:IKey
    {
        public int IdPrinter { get; set; }
        public int IdAgent { get; set; }
        
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdAgent == {0} && IdPrinter == {1}", IdAgent, IdPrinter));
        }
    }
}
