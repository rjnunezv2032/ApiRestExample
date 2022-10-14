using AutoMapper;
using MediatR;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{
    public class PrintJobsBO : Base.GenericBO<TrabajosImpresion, TrabajosImpresionDTO, CodAgenteIpImpresoraKey>, IPrintJobsBO
    {
        private readonly IPrintJobsRepository _PrintJobsRepository;
        public PrintJobsBO(IMapper mapper,
                               IUnitOfWork unitOfWork,
                               IPrintJobsRepository PrintJobsRepository,
                               IMediator mediator) : base(mapper,unitOfWork, PrintJobsRepository, mediator)
        {
            this._PrintJobsRepository = PrintJobsRepository;
        }
        public async Task<List<PrintJobsOutput>> GetPrintJobs(CodAgenteIpImpresoraKey filtros)
        {
            return await _PrintJobsRepository.GetPrintJobs(filtros);
        }
        
        public async Task SetPrintJobs(List<TrabajosImpresion> impresorasUsuario)
        {
            await _PrintJobsRepository.SetPrintJobs(impresorasUsuario);
        }

        //public async Task<string> UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut)
        public async Task UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut)
        {
            await _PrintJobsRepository.UpdatePrintJobs(InPut);
        }

        public async Task<SystemOptionsOutput> GetDeleteJobsInfo()
        {

            return await _PrintJobsRepository.GetDeleteJobsInfo();//.ConfigureAwait(true));
         
        }
    }
}
