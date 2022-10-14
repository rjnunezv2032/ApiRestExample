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
    public class RegistryPrintUsersBO : Base.GenericBO<UsuarioImpresoras, UsuarioImpresorasDTO, IdKey>, IRegistryPrintUsersBO
    {
        private readonly IRegistryPrintsUserRepository _RegistryPrintUsers;

        public RegistryPrintUsersBO(IMapper mapper, IUnitOfWork unitOfWork, 
                                    IRegistryPrintsUserRepository RegistryPrintUsers, IMediator mediator)
                                    :base(mapper,unitOfWork, RegistryPrintUsers, mediator)
        {
            this._RegistryPrintUsers = RegistryPrintUsers;
        }

        public async Task UpdatePrintUser(IdAdmIdUsuarioIdImpresoraKey impresorasUsuario)
        {
            await _RegistryPrintUsers.UpdatePrintUser(impresorasUsuario);
        }

        public async Task SetRegistryPrintUsers(List<IdAdmIdUsuarioIdImpresoraKey> impresorasUsuario)
        {
            await _RegistryPrintUsers.SetRegistryPrintUsers(impresorasUsuario);
        }

    }
}
