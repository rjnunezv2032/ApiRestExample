using System;
using System.Collections.Generic;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Model.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public enum Command
    {
        CloseSocket,
        GetPrintingJobs,
        UpdatePrintingJobs,
        UpdatePrinterStatus
    }
    public class AgentCommand
    {
        public Command Command { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        public List<IdTrabajoIdImpresoraKey> Jobs { get; set; }

        public List<IdPrinterIdAgentIdStatusKey> PrintersStatus { get; set; }
    }
}
