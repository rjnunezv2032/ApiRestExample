using System;

namespace Sonda.Core.RemotePrinting.Model.Entities
{
    public class FileOutput
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int NumberOfPages { get; set; }
        public string DocumentBase64 { get; set; }
        
    }
}