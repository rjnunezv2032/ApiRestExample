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
    public class PropositoBO : Base.GenericBO<Proposito, PropositoDTO, IdPropositoKey>, IPropositoBO
    {
        private readonly IPropositoRepository _PropositoRepository;

        public PropositoBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IPropositoRepository PropositoRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, PropositoRepository, mediator)
        {
            this._PropositoRepository = PropositoRepository;
        }
        public async virtual Task<IEnumerable<Proposito>> GetAll()
        {
            return _mapper.Map<IEnumerable<Proposito>>(await _PropositoRepository.GetAll());
        }
    }
}
