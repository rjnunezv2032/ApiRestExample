using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    //Key de ejemplo 
    public class IdAdmIdUsuarioIdImpresoraKey : IKey
    {
        public virtual int IdAmin { get; set; }
        public virtual string IdUsuario { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual bool? DefaultPrinter { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdAmin == {0} && IdUsuario == {1} && IdImpresora == {2}", IdAmin, IdUsuario, IdImpresora));
        }
    }
}
