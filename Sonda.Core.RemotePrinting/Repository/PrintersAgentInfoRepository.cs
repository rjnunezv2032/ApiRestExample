using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class PrintersAgentInfoRepository : GenericRepository<PrintingAgentsInfoDTO, IdAgenteKey>, IPrintersAgentInfoRepository
    {
        public PrintersAgentInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<List<PrintersAgentInfoOutput>> GetPrintingAgentsInfo(IdAgenteKey filtro)
        {
            try
            {
            var data = new List<PrintersAgentInfoOutput>();
                //Tabla principal
                var lAgentes = await Session.Query<AgenteDTO>().Where(x => x.IdAgente == filtro.IdAgente && x.EstadoReg == "V").ToListAsync();
                //Tablas relacionadas
                var lImpresoras = await Session.Query<PrinterDTO>().Where(x => x.IdAgent == filtro.IdAgente && x.EstadoReg == "V").ToListAsync();


                if (lImpresoras.Count == 0)
                {
                    _UnitOfWork.AddMessage("USU-00001", "No existen impresoras, para el agente indicado");
                }
                else 
                {
            var lPropositos = await Session.Query<PropositoDTO>().ToListAsync();
            var lTmpresorasEstados = await Session.Query<EstadosImpresorasDTO>().ToListAsync();
            var lTipoImpresora = await Session.Query<TipoImpresoraDTO>().ToListAsync();
            var lTipoDocumento = await Session.Query<TipoDocumentoDTO>().ToListAsync();

                foreach (var printer in lImpresoras)
            {
                var IdProp = lImpresoras.Where(y => y.IdPrinter == printer.IdPrinter).Select(y => y.IdPurpose).FirstOrDefault();
                var IdTipoImpresora = lImpresoras.Where(z => z.IdPrinter == printer.IdPrinter).Select(z => z.IdTipoImpresora).FirstOrDefault();
                var IdTipoDocumento = lImpresoras.Where(r => r.IdPrinter == printer.IdPrinter).Select(r => r.IdTipoDocumento).FirstOrDefault();
                var oProposito = lPropositos.Where(y => y.IdProposito == IdProp).FirstOrDefault();
                var oAgente  = lAgentes.Where(y => y.IdAgente == printer.IdAgent).First();
                var oTipoImpresora = lTipoImpresora.Where(x => x.IdTpImpresora == IdTipoImpresora).FirstOrDefault();
                var oImpresoraEstado = lTmpresorasEstados.Where(z => z.IdEstado == printer.IdEstado).FirstOrDefault();
                var oTipoDocumento = lTipoDocumento.Where(x => x.IdTipoDoc == IdTipoDocumento).FirstOrDefault();
                data.Add(new PrintersAgentInfoOutput()
                {
                    IdAgente = printer.IdAgent,
                    IdImpresora = printer.IdPrinter,
                    CodAgente = oAgente.CodAgente,
                    DescripcionAgente = oAgente.DescripcionAgente,
                    NombreImpresora = printer.PrinterName,
                    DescripcionImpresora = printer.Description,
                    Propiedades = printer.PrinterProperties,
                    Parametros = printer.Parameters,
                    IdProposito = printer.IdPurpose,
                    DescripcionProposito = oProposito.DescripcionProposito,
                    IdTpImpresora = oTipoImpresora.IdTpImpresora,
                    DescripcionTpImpresora = oTipoImpresora.DescripcionTpImpresora,
                    IdEstadoImpresora = oImpresoraEstado.IdEstado,
                    DescripcionEstadoImpresora = oImpresoraEstado.DescripcionEstado,
                    IdTipoDoc = oTipoDocumento.IdTipoDoc,
                    DescTipoDoc = oTipoDocumento.DescTipoDoc,
                    MaxDataTranfer = oAgente.MaxDataTranfer,
                });
            }
                }
            return data;
        }
            catch (System.Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo una excepcion => " + ex.Message);
                throw;
            }
        }
    }
}
