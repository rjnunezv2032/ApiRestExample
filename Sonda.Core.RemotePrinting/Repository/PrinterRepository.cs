using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class PrinterRepository : GenericRepository<PrinterDTO, IdImpresoraKey>, IPrinterRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrinterRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<PrinterDTO> GetPrinter(IdImpresoraKey filtros)
        {
            var query = (from printer in Session.Query<PrinterDTO>()
                         where printer.IdPrinter == filtros.IdPrinter
                         select printer).FirstOrDefaultAsync();

            return query;
        }

        public async Task UdpdatePrinterStatus(IdAgenteIdPrinterStatusKey filtro)
        {
            var query = (from printer in Session.Query<PrinterDTO>()
                         where printer.IdPrinter == filtro.IdPrinter &&
                            printer.IdAgent == filtro.IdAgent
                         select printer).FirstAsync();
            PrinterDTO x = query.Result;//.IdEstado = filtro.IdStatus;
            x.IdEstado = filtro.IdStatus;

            await _session.UpdateAsync(x);
            _unitOfWork.AddMessage("USU-00001", "Registro actualizado/modificado con exito.");

        }

    }
}
