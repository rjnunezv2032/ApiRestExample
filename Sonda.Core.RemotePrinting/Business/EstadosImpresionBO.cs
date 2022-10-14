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
{
    public class EstadosImpresionBO : Base.GenericBO<EstadosImpresion, EstadosImpresionDTO, IdEstadoImpresionKey>, IEstadosImpresionBO
    {
        private readonly IEstadosImpresionRepository _EstadosImpresionRepository;

        public EstadosImpresionBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IEstadosImpresionRepository estadosImpresionRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, estadosImpresionRepository, mediator)
        {
            this._EstadosImpresionRepository = estadosImpresionRepository;
        }

        public async virtual  Task<IEnumerable<EstadosImpresion>> GetAll()
        {
            return _mapper.Map<IEnumerable<EstadosImpresion>>(await _EstadosImpresionRepository.GetAll());
        }
    }
}
