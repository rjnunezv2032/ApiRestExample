namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Agente
    {
        public Agente()
        { }

        public virtual int IdAgente{ get; set; }
        public virtual int IdEstado { get; set; }
        public virtual string CodAgente { get; set; }
        public virtual string DescripcionAgente { get; set; } 
        public virtual string UrlAgente { get; set; }
        public virtual string IpAgente { get; set; }
        public virtual int FrecActualizacion { get; set; }
        public virtual int MaxDataTranfer { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Agente t = obj as Agente;
            if (t == null) return false;
            if (IdAgente == t.IdAgente) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAgente.GetHashCode();
            return hash;
            //return base.GetHashCode();
        }
        #endregion

    }
}
