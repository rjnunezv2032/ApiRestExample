using AutoMapper;
using MediatR;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{
    public class AgenteBO : Base.GenericBO<Agente, AgenteDTO, IdAgenteKey>, IAgenteBO
    {
        private readonly IAgenteRepository _AgenteRepository;

        public AgenteBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IAgenteRepository AgenteRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, AgenteRepository, mediator)
        {
            this._AgenteRepository = AgenteRepository;
        }

        public async Task RemovePrinter(IdAgenteKey filtro)
        {
            await _AgenteRepository.RemovePrinter(filtro);
        }
    }
}
