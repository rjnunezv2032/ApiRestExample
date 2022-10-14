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
    public interface ITipoImpresoraBO : IGenericBO<TipoImpresora, IdTipoImpresoraKey>
    {
        Task<IEnumerable<TipoImpresora>> GetAll();
    }
}
