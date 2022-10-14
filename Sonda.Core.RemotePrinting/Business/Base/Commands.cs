using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business.Base
{
    public record OnCreateCommand<TEntity, TDAO>(TEntity entity, TDAO dao) : IRequest<TDAO>;
    public record OnUpdateCommand<TEntity, TDAO>(TEntity entity, TDAO dao) : IRequest<TDAO>;
    public record OnDeleteCommand<TKey, TDAO>(TKey key, TDAO dao) : IRequest<TDAO>;
}
