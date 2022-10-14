using AutoMapper;
using MediatR;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sonda.Api.Common.Helper.Services;

namespace Sonda.Core.RemotePrinting.Business
{
    public class PrinterBO : Base.GenericBO<Printer, PrinterDTO, IdImpresoraKey>, IPrinterBO
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IPrinterRepository printerRepository,
            IMediator mediator)
            : base(mapper,unitOfWork,printerRepository,mediator)
        {
            this._printerRepository = printerRepository;
        }

        public async Task UpdatePrinterStatus(IdAgenteIdPrinterStatusKey filtro)
        {
            await _printerRepository.UdpdatePrinterStatus(filtro);
        }


        //public async Task<Printer> GetPrinter(IdImpresoraKey filtros)
        //{
        //    return _mapper.Map<Printer>(await _printerRepository.GetPrinter(filtros));
        //}

    }
}
