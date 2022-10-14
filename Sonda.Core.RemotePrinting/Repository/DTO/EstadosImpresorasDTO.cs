using System;
using Sonda.Core.RemotePrinting.Repository.Base;

namespace Sonda.Core.RemotePrinting.Repository.DTO
{
    public class EstadosImpresorasDTO : ICamposControl
    {
        public EstadosImpresorasDTO()
        { }

        public virtual int IdEstado { get; set; }
        public virtual string DescripcionEstado { get; set; }
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

            EstadosImpresorasDTO t = obj as EstadosImpresorasDTO;

            if (t == null)
                return false;

            if (IdEstado == t.IdEstado)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdEstado.GetHashCode();
            return hash;
        }
        #endregion

    }
}
