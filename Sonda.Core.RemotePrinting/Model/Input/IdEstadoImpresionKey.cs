using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdEstadoImpresionKey : IKey
    {
        public int IdEstadoImpresion { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdEstadoImpresion == {0}", IdEstadoImpresion));
        }
    }
}
