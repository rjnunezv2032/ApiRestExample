using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Business
{
    public interface IPrintersUserInfoBO : IGenericBO<PrintersUserInfo, IdUsuarioKey>
    {
        Task<List<PrintersUserInfoOutput>> GetUserPrinters(IdUsuarioKey dataInput);
    }
}