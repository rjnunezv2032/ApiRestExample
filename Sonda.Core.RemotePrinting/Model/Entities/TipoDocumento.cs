namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class TipoDocumento
    {
        public TipoDocumento(){ }

        public virtual int IdTipoDoc { get; set; }
        public virtual string DescTipoDoc { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            TipoDocumento t = obj as TipoDocumento;

            if (t == null) 
                return false;

            if (IdTipoDoc == t.IdTipoDoc)
                return true;

            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdTipoDoc.GetHashCode();
            return hash;
        }
        #endregion

    }
}
