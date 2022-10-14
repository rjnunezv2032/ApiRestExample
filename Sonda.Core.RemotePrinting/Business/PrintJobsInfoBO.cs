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
    public class PrintJobsInfoBO : Base.GenericBO<PrintJobsInfo, PrintJobsInfoDTO, IdUsuarioKey>, IPrintJobsInfoBO
    {
        private readonly IPrintJobsInfoRepository _PrintJobsInfoRepository;
        public PrintJobsInfoBO(IMapper mapper,
                               IUnitOfWork unitOfWork,
                               IPrintJobsInfoRepository PrintJobsInfoRepository,
                               IMediator mediator) : base(mapper,unitOfWork, PrintJobsInfoRepository, mediator)
        {
            this._PrintJobsInfoRepository = PrintJobsInfoRepository;
        }
        public async Task<List<PrintJobsInfoOutput>> GetPrintJobsInfo(IdUsuarioKey filtros)
        {
            return await _PrintJobsInfoRepository.GetPrintJobsInfo(filtros);
        }
    }
}
