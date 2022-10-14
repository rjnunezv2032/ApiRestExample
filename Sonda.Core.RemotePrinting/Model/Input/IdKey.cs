using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Model.Input
{

    public class IdKey : IKey
    {
        public IdKey()
        {

        }
        public IdKey(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }

        public override string ToString()
        {
            return (String.Format("Id == {0}", Id));
        }

        public string Expand { get; set; }
    }
}
