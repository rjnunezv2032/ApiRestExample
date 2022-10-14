using AutoMapper;
using DevExpress.Pdf;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using MediatR;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Entities;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Repository;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

//using JobOptionsSetter = Sonda.Core.RemotePrintingAgent.Common.Extensions.PrintJobSettingsHelper;

namespace Sonda.Core.RemotePrinting.Business
{

    public class FileCacheBO : Base.GenericBO<FileOutput, FileOutputDTO, FileInput>, IFileCacheBO
    {
        private readonly IFileCacheRepository _FileCacheRepository;

        public FileCacheBO(IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileCacheRepository FileCacheRepository,
            IMediator mediator)
            : base(mapper, unitOfWork, FileCacheRepository, mediator)
        {
            this._FileCacheRepository = FileCacheRepository;
        }

        public async Task<FileOutputDTO> ConvertToPDFService(FileInput Document)
        {
            return await _FileCacheRepository.ConvertToPDFService(Document);
        }      
    }
}