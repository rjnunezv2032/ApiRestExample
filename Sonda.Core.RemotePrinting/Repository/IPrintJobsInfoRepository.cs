using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IPrintJobsInfoRepository : IGenericRepository<PrintJobsInfoDTO, IdUsuarioKey>
    {
        Task<List<PrintJobsInfoOutput>> GetPrintJobsInfo(IdUsuarioKey filtros);
    }

    
}
