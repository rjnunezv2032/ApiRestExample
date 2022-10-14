using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using Sonda.Core.RemotePrinting.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sonda.Core.RemotePrinting.Repository
{
    public class PrintJobsRepository : GenericRepository<TrabajosImpresionDTO, CodAgenteIpImpresoraKey>, IPrintJobsRepository
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public PrintJobsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._UnitOfWork = unitOfWork;
        }
        public Task<SystemOptionsOutput> GetDeleteJobsInfo() {
            SystemOptionsOutput optionsOutput = new();
            optionsOutput.DeleteJobs = ConstantSettings.EliminarFisicamente;            
            return Task.FromResult(optionsOutput);
        } 
        
        
        
        
        public async Task<List<PrintJobsOutput>> GetPrintJobs(CodAgenteIpImpresoraKey filtros)
        {
            try
            {
                var query = (from trabajosImpr in Session.Query<TrabajosImpresionDTO>()
                             join impresora in Session.Query<PrinterDTO>() on trabajosImpr.IdImpresora equals impresora.IdPrinter
                             join estadoImpr in Session.Query<EstadosImpresionDTO>() on trabajosImpr.IdEstadoImpresion equals estadoImpr.IdEstadoImpresion
                             join agente in Session.Query<AgenteDTO>() on impresora.IdAgent equals agente.IdAgente
                             where agente.CodAgente == filtros.CodAgente &&
                                    agente.IpAgente == filtros.IpAgente &&
                                    trabajosImpr.IdEstadoImpresion != 4 &&
                                   (trabajosImpr.FechaImpresion.Year == DateTime.Now.Year &&
                                    trabajosImpr.FechaImpresion.Month == DateTime.Now.Month &&
                                    trabajosImpr.FechaImpresion.Day == DateTime.Now.Day)
                             select new
                             {
                             impresora.IdPrinter,
                             impresora.PrinterName,
                             trabajosImpr.IdTrabajo,
                             trabajosImpr.IdUsuario,
                             trabajosImpr.NombreArchivo,                             
                             trabajosImpr.Documento,
                             trabajosImpr.ConfigImpresion,
                             trabajosImpr.PosColaImpresion,
                             trabajosImpr.IdEstadoImpresion,
                             estadoImpr.DescripcionEstImp,
                             impresora.IdTipoImpresora,
                             impresora.IdTipoDocumento
                             });
                var list = await query.ToListAsync().ConfigureAwait(false);

                List<PrintJobsOutput> data = new List<PrintJobsOutput>();
                if (list.Count == 0)
                {
                    _UnitOfWork.AddMessage("USU-00001", "No existen trabajos de impresión, para los filtros ingresados");
                }
                else
                { 
                    foreach (var trabajoImpresion in list)
                    {
                        data.Add(new PrintJobsOutput()
                        {
                            IdImpresora = trabajoImpresion.IdPrinter,
                            NombreImpresora = trabajoImpresion.PrinterName,
                            IdTrabajo = trabajoImpresion.IdTrabajo,
                            IdUsuario = trabajoImpresion.IdUsuario,
                            IdEstado = trabajoImpresion.IdEstadoImpresion,
                            NombreArchivo = trabajoImpresion.NombreArchivo,
                            Documento = (trabajoImpresion.IdEstadoImpresion != 1 ? null : trabajoImpresion.Documento),
                            ConfigImpresion = trabajoImpresion.ConfigImpresion,
                            PosColaImpresion = trabajoImpresion.PosColaImpresion,
                            IdTipoDocumento = trabajoImpresion.IdTipoDocumento,
                    		IdTipoImpresora = trabajoImpresion.IdTipoImpresora
                        });
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo un excepcion => " + ex.Message);
                return null;
            }
           
        }
        public async Task SetPrintJobs(List<TrabajosImpresion> printJobs)
        {
            int IdUltimoTrabajo = 0;
            try
            {

                IdUltimoTrabajo = Session.Query<TrabajosImpresionDTO>().ToList().Count == 0 ? 1 : Session.Query<TrabajosImpresionDTO>().Max(x => x.IdTrabajo);

                foreach (var oPrintJob in printJobs)
                {
                    IdUltimoTrabajo++;

                    await base.Create(new TrabajosImpresionDTO()
                    {
                        IdImpresora = oPrintJob.IdImpresora,
                        IdTrabajo = IdUltimoTrabajo,
                        IdEstadoImpresion = oPrintJob.IdEstadoImpresion,
                        NombreArchivo = oPrintJob.NombreArchivo,
                        Documento = oPrintJob.Documento,
                        ConfigImpresion = oPrintJob.ConfigImpresion,
                        PosColaImpresion = oPrintJob.PosColaImpresion,
                        FechaImpresion = DateTime.Now,
                        IdUsuario = oPrintJob.IdUsuario
                    });
                }

                //_UnitOfWork.AddMessage("USU-00001", "Los trabajos de impresión han sido creados");
            }
            catch (Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo un excepcion => " + ex.Message);
            }
        }
        public async Task UpdatePrintJobs(IdTrabajoIdImpresoraKey InPut)
        {
            
            bool bActualizo = false;
            bool bElimina = ConstantSettings.EliminarFisicamente;

            try
            {
                var oPrintJob = Session.Query<TrabajosImpresionDTO>()
               .Where(x => x.EstadoReg == "V" &&
                      x.IdTrabajo == InPut.IdTrabajo &&
                      x.IdImpresora == InPut.IdImpresora &&
                     (x.FechaImpresion.Year == DateTime.Now.Year &&
                      x.FechaImpresion.Month == DateTime.Now.Month &&
                      x.FechaImpresion.Day == DateTime.Now.Day)
                       )
                       .FirstOrDefault();

                if (oPrintJob == null)
                {
                    _UnitOfWork.AddMessage("SYS-00001", "No existen trabajos de impresión");
                    //return;
                }
                #region Tabla de estados de trabajos de impresion            
                //pendiente = 1,
                //imprimiendo = 2,
                //pausado = 3,
                //finalizado = 4,
                //cancelado = 5
                #endregion

                #region case
                switch ((eEstImp)InPut.IdEstadoImpresion)
                {
                    case eEstImp.pendiente:

                        if (oPrintJob.IdEstadoImpresion == InPut.IdEstadoImpresion) //estado tabla  = estado imput -> no hacer nada
                            bActualizo = false;
                        break;
                    case eEstImp.imprimiendo:
                        if (oPrintJob.IdEstadoImpresion == InPut.IdEstadoImpresion) //estado tabla  = estado imput -> no hacer nada
                            bActualizo = false;
                        else
                            //actualiza -> si y solo si el estado de trabajo (en la tabla) = Pendiente o Pausado
                            if (oPrintJob.IdEstadoImpresion == (int)eEstImp.pendiente || oPrintJob.IdEstadoImpresion == (int)eEstImp.pausado)
                            {
                                await ActualizaEstadoDeImpresion(InPut, oPrintJob);
                                bActualizo = true;
                            }
                        break;
                    case eEstImp.pausado:
                        if (oPrintJob.IdEstadoImpresion == InPut.IdEstadoImpresion)  //estado tabla  = estado imput -> no hacer nada
                            bActualizo = false;
                        else
                            //actualiza -> si y solo si el estado de trabajo (en la tabla) = imprimiendo
                            if (oPrintJob.IdEstadoImpresion == (int)eEstImp.imprimiendo)
                            {
                                await ActualizaEstadoDeImpresion(InPut, oPrintJob);
                                bActualizo = true;
                            }
                        break;
                    case eEstImp.finalizado:
                        if (oPrintJob.IdEstadoImpresion == InPut.IdEstadoImpresion)//estado tabla  = estado imput -> no hacer nada
                            bActualizo = false;
                        else
                            //actualiza -> si y solo si el estado de trabajo (en la tabla)= imprimiendo 
                            if (oPrintJob.IdEstadoImpresion == (int)eEstImp.imprimiendo) //(termino de imprimir fisicamente)
                            {
                                //-> eliminar registro fisico si y solo si esta configurado para eliminar.
                                if (bElimina)
                                    await EliminaRegistroDeTrabajoImpresion(InPut, oPrintJob);//se elimina del registro de tabla SIR_TRABAJOS_IMPRESION
                                else
                                    await ActualizaEstadoDeImpresion(InPut, oPrintJob);
                                bActualizo = true;
                            }
                            break;
                    case eEstImp.cancelado:
                            if (oPrintJob.IdEstadoImpresion == InPut.IdEstadoImpresion) //estado tabla  = estado imput -> no hacer nada
                                bActualizo = false;
                            else
                                //actualiza -> si y solo si el estado de trabajo (en la tabla) = imprimiendo, pausado,pendiente
                                if (oPrintJob.IdEstadoImpresion == (int)eEstImp.imprimiendo ||
                                    oPrintJob.IdEstadoImpresion == (int)eEstImp.pausado ||
                                    oPrintJob.IdEstadoImpresion == (int)eEstImp.pendiente)
                                    {
                                        if (bElimina)
                                            await EliminaRegistroDeTrabajoImpresion(InPut, oPrintJob);//se elimina del registro de tabla SIR_TRABAJOS_IMPRESION
                                        else
                                            await ActualizaEstadoDeImpresion(InPut, oPrintJob);
                                        bActualizo = true;
                                    }
                        break;
                }
                #endregion

                if (bActualizo)
                       _UnitOfWork.AddMessage("USU-00001", "El registro ha sido modificado");
                else
                       _UnitOfWork.AddMessage("USU-00002", "El registro no fue modificado");
            }
            catch (Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo una excepcion => " + ex.Message);
            }
        }
        private async Task EliminaRegistroDeTrabajoImpresion(IdTrabajoIdImpresoraKey InPut, TrabajosImpresionDTO oPrintJob)
        {
            oPrintJob.IdTrabajo = InPut.IdTrabajo;
            oPrintJob.IdImpresora = InPut.IdImpresora;
            await Session.DeleteAsync(oPrintJob);
        }
        private async Task ActualizaEstadoDeImpresion(IdTrabajoIdImpresoraKey InPut, TrabajosImpresionDTO oPrintJob)
        {
            oPrintJob.IdTrabajo = InPut.IdTrabajo;
            oPrintJob.IdImpresora = InPut.IdImpresora;
            oPrintJob.IdEstadoImpresion = InPut.IdEstadoImpresion;
            await Session.UpdateAsync(oPrintJob);
        }
    }
}