using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdUsuarioKey : IKey
    {
        public string IdUsuario { get; set; }

        public DateTime fechaImpresion { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdUsuario == {0}", IdUsuario));
        }
    }
}
