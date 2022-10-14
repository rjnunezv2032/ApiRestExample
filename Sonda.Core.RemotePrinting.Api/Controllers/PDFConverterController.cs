using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Business;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.IO;

namespace Sonda.Core.RemotePrinting.Api.Controllers
{
    [ApiVersion("1.0")]
    public class PDFConverterController : Base.GenericController<FileOutput, FileInput>
    {
        private readonly IFileCacheBO IFileCacheBO;

        public PDFConverterController( ILogger<PDFConverterController> logger,
                                IFileCacheBO FileCacheBO,
                                IGenericBO<FileOutput, FileInput> genericBO,
                                IUnitOfWork unitOfWork) : base(logger, genericBO, unitOfWork)
        {
            this.IFileCacheBO = FileCacheBO;
        }

   
        [HttpPost]
        [Route("ConvertToPDFService")]
        [SwaggerOperation(Summary = "ConvertToPDFService", Description = "ConvertToPDFService")]
        public async Task<IActionResult> ConvertToPDFService(FileInput Document) 
        {
            var res = await _unitOfWork.Execute(async () =>
            {
                return await IFileCacheBO.ConvertToPDFService(Document);
            });
            return res.GetStatus(this);
        }
    }
}
