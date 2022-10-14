using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Entities;


namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IAgenteRepository : IGenericRepository<AgenteDTO, IdAgenteKey>
    {
        Task RemovePrinter(IdAgenteKey filtro);
    }
}
