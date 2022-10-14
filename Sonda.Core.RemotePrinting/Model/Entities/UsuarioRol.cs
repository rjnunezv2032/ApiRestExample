namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class UsuarioRol
    {
        public UsuarioRol() { }
        public virtual short IdAdm { get; set; }
        public virtual string IdUsuario { get; set; }
        public virtual string IdRol { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
        //public virtual string EstadoReg { get; set; }
        //public virtual DateTime? FecEstadoReg { get; set; }
        //public virtual DateTime? FecIngReg { get; set; }
        //public virtual string IdUsuarioIngReg { get; set; }
        //public virtual DateTime? FecUltModifReg { get; set; }
        //public virtual string IdUsuarioUltModifReg { get; set; }
        //public virtual string IdFuncionUltModifReg { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            UsuarioRol t = obj as UsuarioRol;
            if (t == null) return false;
            if (IdAdm == t.IdAdm
             && IdUsuario == t.IdUsuario
             && IdRol == t.IdRol)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAdm.GetHashCode();
            hash = (hash * 397) ^ IdUsuario.GetHashCode();
            hash = (hash * 397) ^ IdRol.GetHashCode();

            return hash;
        }
        #endregion
    }
}
