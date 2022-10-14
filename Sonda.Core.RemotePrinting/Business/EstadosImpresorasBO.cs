using AutoMapper;
using MediatR;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{    public class EstadosImpresorasBO : Base.GenericBO<EstadosImpresoras, EstadosImpresorasDTO, IdEstadoImpresoraKey>, IEstadosImpresorasBO
    {
        private readonly IEstadosImpresorasRepository _EstadosImpresorasRepository;
        public EstadosImpresorasBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IEstadosImpresorasRepository estadosImpresorasRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, estadosImpresorasRepository, mediator)
        {
            this._EstadosImpresorasRepository = estadosImpresorasRepository;
        }
        public async virtual Task<IEnumerable<EstadosImpresoras>> GetAll()
        {
            return _mapper.Map<IEnumerable<EstadosImpresoras>>(await _EstadosImpresorasRepository.GetAll());
        }
    }
}
