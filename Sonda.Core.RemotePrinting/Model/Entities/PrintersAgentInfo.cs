using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class PrintersAgentInfo
    {
        PrintersAgentInfo()
        { }

        public virtual int IdAgente { get; set; }
        public virtual int IdImpresora { get; set; }
        public virtual int IdProposito { get; set; }
        public virtual int IdTpImpresora { get; set; }
        public virtual int IdEstado { get; set; }
        public virtual int IdTipoDoc { get; set; }
        public virtual int IdAdm { get; set; }
        public virtual string IdUsuario { get; set; }
        public virtual string CodAgente { get; set; }
        public virtual string DescripcionAgente { get; set; }
        public virtual string NombreImpresora { get; set; }
        public virtual string DescripcionImpresora { get; set; }
        public virtual string ImpresoraDefaault { get; set; }
        public virtual string Propiedades { get; set; }
        public virtual string Parametros { get; set; }
        public virtual string DescripcionProposito { get; set; }
        public virtual string DescripcionTpImpresora { get; set; }
        public virtual string DescripcionEstadoImpresora { get; set; }
        public virtual string DescTipoDoc { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PrintersAgentInfo t = obj as PrintersAgentInfo;
            if (t == null) return false;
            if (IdAgente == t.IdAgente) return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ IdAgente.GetHashCode();
            return hash;
        }
    }
}
