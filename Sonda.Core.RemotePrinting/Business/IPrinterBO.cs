using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;


namespace Sonda.Core.RemotePrinting.Business
{
    public interface IPrinterBO : IGenericBO<Printer, IdImpresoraKey>
    {
        //Task<Printer> GetPrinter(IdImpresoraKey filtros);

        Task UpdatePrinterStatus(IdAgenteIdPrinterStatusKey filtro);
    }
}
