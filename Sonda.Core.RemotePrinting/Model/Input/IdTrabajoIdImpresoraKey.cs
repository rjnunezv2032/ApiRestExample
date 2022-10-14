using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class IdTrabajoIdImpresoraKey : IKey
    {
        public virtual int IdTrabajo { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual int IdEstadoImpresion { get; set; }
        public virtual int PosColaImpresion { get; set; }
        public virtual DateTime fechaImpresion { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdTrabajo == {0} && IdImpresora == {1}", IdTrabajo, IdImpresora));
        }
    }
}
