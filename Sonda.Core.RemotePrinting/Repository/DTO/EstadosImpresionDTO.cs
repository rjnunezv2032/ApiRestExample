using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class EstadosImpresionDTO : ICamposControl
    {
        public EstadosImpresionDTO()
        { }

        public virtual int IdEstadoImpresion { get; set; }
        public virtual string DescripcionEstImp { get; set; }

        //Campos de auditoria
        public virtual string EstadoReg { get; set; }
        public virtual DateTime? FecEstadoReg { get; set; }
        public virtual DateTime? FecIngReg { get; set; }
        public virtual string IdUsuarioIngReg { get; set; }
        public virtual DateTime? FecUltModifReg { get; set; }
        public virtual string IdUsuarioUltModifReg { get; set; }
        public virtual string IdFuncionUltModifReg { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            EstadosImpresionDTO t = obj as EstadosImpresionDTO;

            if (t == null)
                return false;

            if (IdEstadoImpresion == t.IdEstadoImpresion)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdEstadoImpresion.GetHashCode();
            return hash;
        }
        #endregion

    }
}
