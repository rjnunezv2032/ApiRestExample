using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System.Threading.Tasks;
using System.IO;

namespace Sonda.Core.RemotePrinting.Business
{
    /// <summary>
    /// Conversion y manejo interno de archivos para los trabajos de impresion.
    /// </summary>
    public interface IFileCacheBO
    {
        Task<FileOutputDTO> ConvertToPDFService(FileInput Document);
    }
}