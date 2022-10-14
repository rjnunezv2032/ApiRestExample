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
    public class PrintersUserInfoRepository : GenericRepository<PrintersUserInfoDTO, IdUsuarioKey>, IPrintersUserInfoRepository
    {
        public PrintersUserInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<List<PrintersUserInfoOutput>> GetUserPrinters(IdUsuarioKey dataInput)
        {
            try
            {
             var query = (from agente in  Session.Query<AgenteDTO>()
                            join impresora in Session.Query<PrinterDTO>() on agente.IdAgente equals impresora.IdAgent
                            join proposito in Session.Query<PropositoDTO>() on impresora.IdPurpose equals proposito.IdProposito
                            join tipoImp in Session.Query<TipoImpresoraDTO>() on impresora.IdTipoImpresora equals tipoImp.IdTpImpresora
                            join estadoImp in Session.Query<EstadosImpresorasDTO>() on impresora.IdEstado equals estadoImp.IdEstado
                            join tipoDoc in Session.Query<TipoDocumentoDTO>() on impresora.IdTipoDocumento equals tipoDoc.IdTipoDoc
                            join userImp in Session.Query<UsuarioImpresorasDTO>() on impresora.IdPrinter equals userImp.IdImpresora
                            where userImp.IdUsuario == dataInput.IdUsuario
                             select new
                             {
                                 agente.IdAgente,
                                            userImp.IdAdmin,
                                            userImp.IdUsuario,
                                            agente.CodAgente,
                                            agente.DescripcionAgente,
                                            agente.MaxDataTranfer,
                                            impresora.IdPrinter,
                                            impresora.PrinterName,
                                            impresora.Description,
                                            impresora.PrinterProperties,
                                            impresora.Parameters,
                                            userImp.ImpresoraDefault,
                                            proposito.IdProposito,
                                            proposito.DescripcionProposito,
                                            tipoImp.IdTpImpresora,
                                            tipoImp.DescripcionTpImpresora,
                                            estadoImp.IdEstado,
                                            estadoImp.DescripcionEstado,
                                            tipoDoc.IdTipoDoc,
                                 tipoDoc.DescTipoDoc
                             });

            var list = await query.ToListAsync().ConfigureAwait(false);
                List<PrintersUserInfoOutput> data = new List<PrintersUserInfoOutput>();
                if (list.Count == 0)
                {
                    _UnitOfWork.AddMessage("USU-00001", "No existen impresoras, para el usuario indicado");
                }
                else
                {

            foreach (var usuImp in list)
            {
                data.Add(new PrintersUserInfoOutput()
                {
                    IdUsuario = usuImp.IdUsuario,
                    IdAdm   = usuImp.IdAdmin,
                    IdAgente = usuImp.IdAgente,
                    CodAgente = usuImp.CodAgente,
                    DescripcionAgente = usuImp.DescripcionAgente,
                    IdImpresora = usuImp.IdPrinter,
                    NombreImpresora = usuImp.PrinterName,
                    DescripcionImpresora = usuImp.Description,
                    Propiedades = usuImp.PrinterProperties,
                    Parametros = usuImp.Parameters,
                    IdProposito = usuImp.IdProposito,
                    DescripcionProposito = usuImp.DescripcionProposito,
                    IdTpImpresora = usuImp.IdTpImpresora,
                    DescripcionTpImpresora = usuImp.DescripcionTpImpresora,
                    IdEstadoImpresora = usuImp.IdEstado,
                    DescripcionEstadoImpresora = usuImp.DescripcionEstado,
                    MaxDataTranfer = usuImp.MaxDataTranfer,
                    IdTipoDoc = usuImp.IdTipoDoc,
                    DescTipoDoc = usuImp.DescTipoDoc,
                    ImpresoraDefault = usuImp.ImpresoraDefault,

                });
            }
                }
                return data;

        }
            catch (System.Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo una excepcion => " + ex.Message);
                return null;
            }
        }
    }
}
