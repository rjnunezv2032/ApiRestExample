using Microsoft.AspNetCore.Mvc;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public interface IAgentPrintRepository : IGenericRepository<TrabajosImpresionDTO, IdKey>
    {
        Task SetRegistryPrintAgents(AgenteDTO agenteDTO, Printer ImpresoraDTO);
    }
}
