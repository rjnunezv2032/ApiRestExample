using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdEstadoImpresoraKey : IKey
    {
        public int IdEstado { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdEstado == {0}", IdEstado));
        }
    }
}
