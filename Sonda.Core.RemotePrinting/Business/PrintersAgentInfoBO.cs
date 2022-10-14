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
    public class PrintersAgentInfoBO : Base.GenericBO<PrintersAgentInfo,PrintingAgentsInfoDTO, IdAgenteKey>, IPrintersAgentInfoBO
    {
        private readonly IPrintersAgentInfoRepository _PrintingAgentsInfoRepository;
        public PrintersAgentInfoBO(IMapper mapper,
                                    IUnitOfWork unitOfWork,
                                    IPrintersAgentInfoRepository PrintingAgentsInfoRepository,
                                    IMediator mediator) : base(mapper,unitOfWork, PrintingAgentsInfoRepository, mediator)
        {
            this._PrintingAgentsInfoRepository = PrintingAgentsInfoRepository;
        }
        public async Task<List<PrintersAgentInfoOutput>> GetPrintingAgentsInfo(IdAgenteKey dataInput)
        {
            return await _PrintingAgentsInfoRepository.GetPrintingAgentsInfo(dataInput);
        }
    }
}
