using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IPrintJobsRepository : IGenericRepository<TrabajosImpresionDTO, CodAgenteIpImpresoraKey>
    {
        Task<List<PrintJobsOutput>> GetPrintJobs(CodAgenteIpImpresoraKey filtros);
        Task SetPrintJobs(List<TrabajosImpresion> impresorasUsuario);
        //Task<string> UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut);
        Task UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut);
        Task<SystemOptionsOutput> GetDeleteJobsInfo();
    }

    
}
