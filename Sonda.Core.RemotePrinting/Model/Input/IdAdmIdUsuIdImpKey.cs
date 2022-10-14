using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdAdmIdUsuIdImpKey : IKey
    {
        public int IdAdm { get; set; }
        public string IdUsuario { get; set; }
        public int IdImpresora { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdAdm == {0} && IdUsuario == {1} && IdImpresora == {2}", IdAdm, IdUsuario, IdImpresora));
        }
    }
}
