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
    public class TipoImpresoraBO : Base.GenericBO<TipoImpresora, TipoImpresoraDTO, IdTipoImpresoraKey>, ITipoImpresoraBO
    {
        private readonly ITipoImpresoraRepository _TipoImpresoraRepository;

        public TipoImpresoraBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITipoImpresoraRepository TipoImpresoraRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, TipoImpresoraRepository, mediator)
        {
            this._TipoImpresoraRepository = TipoImpresoraRepository;
        }
        public async virtual Task<IEnumerable<TipoImpresora>> GetAll()
        {
            return _mapper.Map<IEnumerable<TipoImpresora>>(await _TipoImpresoraRepository.GetAll());
        }
    }
}
