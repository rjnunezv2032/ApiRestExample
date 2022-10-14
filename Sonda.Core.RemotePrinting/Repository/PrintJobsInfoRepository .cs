using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class PrintJobsInfoRepository : GenericRepository<PrintJobsInfoDTO, IdUsuarioKey>, IPrintJobsInfoRepository
    {
        protected readonly IUnitOfWork _UnitOfWork;
        public PrintJobsInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            this._UnitOfWork = unitOfWork;
        }

        public async Task<List<PrintJobsInfoOutput>> GetPrintJobsInfo(IdUsuarioKey filtros)
        {
            try
            {
                var query = (from agente in Session.Query<AgenteDTO>()
                             join impresora in Session.Query<PrinterDTO>() on agente.IdAgente equals impresora.IdAgent
                             join userImp in Session.Query<UsuarioImpresorasDTO>() on impresora.IdPrinter equals userImp.IdImpresora
                             join trabImpres in Session.Query<TrabajosImpresionDTO>() on new { x1 = userImp.IdUsuario, x2 = userImp.IdImpresora } equals new { x1 = trabImpres.IdUsuario, x2 = trabImpres.IdImpresora }
                             join proposito in Session.Query<PropositoDTO>() on impresora.IdPurpose equals proposito.IdProposito
                             join tipoImp in Session.Query<TipoImpresoraDTO>() on impresora.IdTipoImpresora equals tipoImp.IdTpImpresora
                             join estadoImpresoras in Session.Query<EstadosImpresorasDTO>() on impresora.IdEstado equals estadoImpresoras.IdEstado
                             join tipoDoc in Session.Query<TipoDocumentoDTO>() on impresora.IdTipoDocumento equals tipoDoc.IdTipoDoc
                             join estadosImpresion in Session.Query<EstadosImpresionDTO>() on trabImpres.IdEstadoImpresion equals estadosImpresion.IdEstadoImpresion


                             where userImp.IdUsuario == filtros.IdUsuario && (trabImpres.FechaImpresion.Year == filtros.fechaImpresion.Year &&
                                                                              trabImpres.FechaImpresion.Month == filtros.fechaImpresion.Month &&
                                                                              trabImpres.FechaImpresion.Day == filtros.fechaImpresion.Day)

                             orderby impresora.IdAgent, trabImpres.PosColaImpresion ascending
                             select new
                             {
                                 userImp.IdUsuario,
                                 userImp.IdAdmin,
                                 agente.IdAgente,
                                 impresora.IdPrinter,
                                 estadoImpresoras.IdEstado,
                                 tipoDoc.IdTipoDoc,
                                 tipoImp.IdTpImpresora,
                                 estadosImpresion.IdEstadoImpresion,
                                 trabImpres.IdTrabajo,
                                 proposito.IdProposito,
                                 userImp.ImpresoraDefault,
                                 trabImpres.NombreArchivo,
                                 trabImpres.Documento,
                                 trabImpres.ConfigImpresion,
                                 trabImpres.PosColaImpresion,
                                 agente.CodAgente,
                                 agente.DescripcionAgente,
                                 impresora.PrinterName,
                                 impresora.Description,
                                 impresora.PrinterProperties,
                                 impresora.Parameters,
                                 estadoImpresoras.DescripcionEstado,
                                 proposito.DescripcionProposito,
                                 tipoImp.DescripcionTpImpresora,
                                 estadosImpresion.DescripcionEstImp,
                                 tipoDoc.DescTipoDoc
                             });

                var list = await query.ToListAsync().ConfigureAwait(false);

                List<PrintJobsInfoOutput> data = new List<PrintJobsInfoOutput>();
                if (list == null)
                {
                    _UnitOfWork.AddMessage("ImpRemota", "No existen trabajos de impresión");
                }
                else
                {
                    foreach (var trabImp in list)
                    {
                        data.Add(new PrintJobsInfoOutput()
                        {
                            IdUsuario = trabImp.IdUsuario,
                            IdAdmin = trabImp.IdAdmin,
                            IdAgente = trabImp.IdAgente,
                            IdImpresora = trabImp.IdPrinter,
                            IdEstadoImpresora = trabImp.IdEstado,
                            IdTipoDoc = trabImp.IdTipoDoc,
                            IdTpImpresora = trabImp.IdTpImpresora,
                            IdEstadoImpresion = trabImp.IdEstadoImpresion,
                            IdTrabajo = trabImp.IdTrabajo,
                            IdProposito = trabImp.IdProposito,
                            ImpresoraDefault = trabImp.ImpresoraDefault,
                            NombreArchivo = trabImp.NombreArchivo,
                            Documento = null, //trabImp.Documento,
                            ConfigImpresion = trabImp.ConfigImpresion,
                            PosColaImpresion = trabImp.PosColaImpresion,
                            CodAgente = trabImp.CodAgente,
                            DescripcionAgente = trabImp.DescripcionAgente,
                            NombreImpresora = trabImp.PrinterName,
                            DescripcionImpresora = trabImp.Description,
                            Propiedades = trabImp.PrinterProperties,
                            Parametros = trabImp.Parameters,
                            DescripcionEstadoImpresora = trabImp.DescripcionEstado,
                            DescripcionProposito = trabImp.DescripcionProposito,
                            DescripcionTpImpresora = trabImp.DescripcionTpImpresora,
                            DescripcionEstImpresion = trabImp.DescripcionEstImp,
                            DescTipoDoc = trabImp.DescTipoDoc,
                        });
                    }
                }
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
