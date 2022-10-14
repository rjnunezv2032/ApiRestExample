using System;

namespace Sonda.Core.RemotePrinting.Model.Input
{
    public class FileInput : IKey
    {
        public int IdFile { get; set; }
        public string DocumentName { get; set; }
        //public virtual byte[] DocumentBase64 { get; set; }
        public string DocumentBase64 { get; set; }
        public string Expand { get; set; }
        public override string ToString()
        {
            return (String.Format("IdFile == {0}", IdFile));
        }
    }
}