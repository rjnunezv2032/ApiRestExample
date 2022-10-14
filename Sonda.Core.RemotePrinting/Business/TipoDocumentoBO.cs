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
    public class TipoDocumentoBO : Base.GenericBO<TipoDocumento, TipoDocumentoDTO, IdTipoDocumentoKey>, ITipoDocumentoBO
    {
        private readonly ITipoDocumentoRepository _TipoDocumentoRepository;

        public TipoDocumentoBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITipoDocumentoRepository TipoDocumentoRepository,
            IMediator mediator)
            : base(mapper,unitOfWork, TipoDocumentoRepository, mediator)
        {
            this._TipoDocumentoRepository = TipoDocumentoRepository;
        }
        public async virtual Task<IEnumerable<TipoDocumento>> GetAll()
        {
            return _mapper.Map<IEnumerable<TipoDocumento>>(await _TipoDocumentoRepository.GetAll());
        }
    }
}
