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
    public class PrintersUserInfoBO : Base.GenericBO<PrintersUserInfo,PrintersUserInfoDTO, IdUsuarioKey>, IPrintersUserInfoBO
    {
        private readonly IPrintersUserInfoRepository _PrintersUserInfoRepository;
        public PrintersUserInfoBO(IMapper mapper,
                                    IUnitOfWork unitOfWork,
                                    IPrintersUserInfoRepository PrintersUserInfoRepository,
                                    IMediator mediator) : base(mapper,unitOfWork, PrintersUserInfoRepository, mediator)
        {
            this._PrintersUserInfoRepository = PrintersUserInfoRepository;
        }
        public async Task<List<PrintersUserInfoOutput>> GetUserPrinters(IdUsuarioKey dataInput)
        {
            return await _PrintersUserInfoRepository.GetUserPrinters(dataInput);
        }
    }
}
