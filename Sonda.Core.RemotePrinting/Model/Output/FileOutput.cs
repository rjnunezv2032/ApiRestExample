using System;

namespace Sonda.Core.RemotePrinting.Model.Output
{
    public class FileOutput
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentBase64 { get; set; }
        public int DocumentLength { get; set; }
    }
}