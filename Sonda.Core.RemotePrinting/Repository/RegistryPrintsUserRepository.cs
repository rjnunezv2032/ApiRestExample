using NHibernate.Linq;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class RegistryPrintsUserRepository : GenericRepository<UsuarioImpresorasDTO, IdKey>, IRegistryPrintsUserRepository
    {
        public RegistryPrintsUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task UpdatePrintUser(IdAdmIdUsuarioIdImpresoraKey impresorasUsuario)
        {
            try
            {
                #region Validación :
                //Solo puede crear una impresora por defecto
                if (impresorasUsuario.DefaultPrinter == true)
                {
                    var query = (from usuImp in Session.Query<UsuarioImpresorasDTO>()
                                 where usuImp.ImpresoraDefault == true && usuImp.IdUsuario == impresorasUsuario.IdUsuario
                                 select new {usuImp});

                    var list = await query.ToListAsync().ConfigureAwait(false);

                    if (list.Count > 0)
                    {
                        _UnitOfWork.AddMessage("USU-00001", "Solo puede seleccionar una impresora por Defecto");
                        return;
                    }
                }
                #endregion

                await base.Update(new UsuarioImpresorasDTO()
                {
                    IdAdmin = impresorasUsuario.IdAmin,
                    IdImpresora = impresorasUsuario.IdImpresora,
                    IdUsuario = impresorasUsuario.IdUsuario,
                    ImpresoraDefault = impresorasUsuario.DefaultPrinter,
                    EstadoReg = "V",
                    FecEstadoReg = DateTime.Now,
                    FecIngReg = DateTime.Now,
                    IdUsuarioIngReg = "ADM",
                    FecUltModifReg = DateTime.Now,
                    IdUsuarioUltModifReg = "ADM",
                    IdFuncionUltModifReg = "ImpresionRemota",

                });

                _UnitOfWork.AddMessage("USU-00001", "El registro ha sido modificado");
            }
            catch (Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo un excepcion => " + ex.Message); 
            }

        }
        public async Task SetRegistryPrintUsers(List<IdAdmIdUsuarioIdImpresoraKey> impresorasUsuario)
        {
            try
                {
                //Borrar las impresoras antes de insertar la nueva lista
                  var query = Session.Query<UsuarioImpresorasDTO>().Where(x => x.IdUsuario == impresorasUsuario.First().IdUsuario).Delete();

                foreach (var usuImp in impresorasUsuario)
                {
                    await base.Create(new UsuarioImpresorasDTO()
                    {
                        IdAdmin = usuImp.IdAmin,
                        IdImpresora = usuImp.IdImpresora,
                        IdUsuario = usuImp.IdUsuario,
                        ImpresoraDefault = false,
                        EstadoReg = "V",
                        FecEstadoReg = DateTime.Now,
                        FecIngReg = DateTime.Now,
                        IdUsuarioIngReg = "ADM",
                        FecUltModifReg = DateTime.Now,
                        IdUsuarioUltModifReg = "ADM",
                        IdFuncionUltModifReg = "ImpresionRemota",
                    });

                }
                _UnitOfWork.AddMessage("USU-00001", "Los registros han sido creados");
            }
            catch (Exception ex)
            {
                _UnitOfWork.AddMessage("SYS-00001", "Se produjo una excepcion => " + ex.Message);
            }
        }
    }
}