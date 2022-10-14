using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdPrinterIdAgentIdStatusKey : IKey
    {

        public virtual int IdImpresora{ get; set; }
        public virtual int IdAgente { get; set; }

        public virtual int idEstadoImpresora { get; set; }

        public virtual string CodAgente { get; set; }

        public virtual string Expand { get; set; }
    }
}
