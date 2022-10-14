using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository.Base
{
    public interface ICamposControl
    {
        public string EstadoReg { get; set; }
        public DateTime? FecEstadoReg { get; set; }
        public DateTime? FecIngReg { get; set; }
        public string IdUsuarioIngReg { get; set; }
        public DateTime? FecUltModifReg { get; set; }
        public string IdUsuarioUltModifReg { get; set; }
        public string IdFuncionUltModifReg { get; set; }

    }
}

