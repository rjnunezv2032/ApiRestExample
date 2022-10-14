using System;
using System.Collections.Generic;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Usuario
    {
        public Usuario() { }
        public virtual short IdAdm { get; set; }
        public virtual string IdUsuario { get; set; }
        public virtual string IdPersona { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Direccion { get; set; }
        public virtual short CodCargo { get; set; }
        public virtual int CodAgencia { get; set; }
        public virtual int CodComuna { get; set; }
        public virtual int CodArea { get; set; }
        public virtual string IndBloqueo { get; set; }
        public virtual string IdUsuarioJefe { get; set; }
        public virtual string Clave { get; set; }
        public virtual DateTime FecExpClave { get; set; }
        public virtual short? CantIntentos { get; set; }
        public virtual DateTime? FecUltIngreso { get; set; }
        public virtual string CodSafp { get; set; }
        public virtual string Email { get; set; }
        public virtual string IdActiveDirectory { get; set; }
        public virtual string HashIntegridad { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Usuario t = obj as Usuario;
            if (t == null) return false;
            if (IdAdm == t.IdAdm
             && IdUsuario == t.IdUsuario)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdm.GetHashCode();
            hash = (hash * 397) ^ IdUsuario.GetHashCode();

            return hash;
        }
        #endregion

        //public virtual TipoCargo Cargo { get; set; }

        public virtual IList<UsuarioRol> UsuarioRoles { get; protected set; }

        //public virtual Comuna Comuna { get; protected set; }

    }
}
