namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class Printer
    {
        public Printer()
        { }

        public virtual int IdPrinter { get; set; }
        public virtual int IdAgent { get; set; }
        public virtual int IdEstado { get; set; }
        public virtual int IdTipoDocumento { get; set; }
        public virtual int IdTipoImpresora { get; set; }
        public virtual int IdPurpose { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual string Description { get; set; }
        public virtual string IpLocation { get; set; }
        public virtual string PrinterProperties { get; set; }
        public virtual string Parameters { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Printer t = obj as Printer;
            if (t == null) return false;
            if (IdPrinter == t.IdPrinter) return true;
            return false;            
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdPrinter.GetHashCode();
            return hash;
            //return base.GetHashCode();
        }

    }
}
