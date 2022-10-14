using DevExpress.Pdf;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using Sonda.Core.DbConn.UnitOfWork;
using Sonda.Core.RemotePrinting.Model.Input;
using Sonda.Core.RemotePrinting.Model.Output;
using Sonda.Core.RemotePrinting.Repository.Base;
using Sonda.Core.RemotePrinting.Repository.DTO;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sonda.Core.RemotePrinting.Repository
{
    public class FileCacheRepository : GenericRepository<FileOutputDTO, FileInput>, IFileCacheRepository
    {
        protected readonly IUnitOfWork _UnitOfWork;
        public FileCacheRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            this._UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Convierte la cadena en base64 en archivo
        /// </summary>
        /// <param name="fileName">nombre de archivo a restaurar de cadena Base64</param>
        /// <param name="fileContent">contenido del archivo.</param>
        /// <returns>FileInfo</returns>
        private FileInfo SaveFileToTempDirectoryAsync(string fileName, string fileContent)
        {
            try
            {
                fileName = Path.Combine(Path.GetTempPath(), fileName);
                //fileName = Path.Combine(_config.TemporaryFolder, fileName);
                File.WriteAllBytesAsync(fileName, Convert.FromBase64String(fileContent));
                return new FileInfo(fileName);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{RemoteAgentExtensions.GetCallerName()}:\t{ex.Message}", ex);
            }
            return null;
        }

        /// <summary>
        /// Convierte la cadena en base64 en archivo
        /// </summary>
        /// <param name="fileName">nombre de archivo a restaurar de cadena Base64</param>
        /// <param name="fileContent">contenido del archivo.</param>
        /// <returns>FileInfo</returns>
        private FileInfo SaveFileToTempDirectory(string fileName, string fileContent)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + f.Extension);
                File.WriteAllBytes(fileName, Convert.FromBase64String(fileContent));
                return new FileInfo(fileName);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{RemoteAgentExtensions.GetCallerName()}:\t{ex.Message}", ex);
            }
            return null;
        }

        /// <summary>
        /// Convierte a PDF archivos xlsx/docx (async)
        /// </summary>
        /// <param name="file">FileInfo con el archivo a convertir.</param>
        /// <returns>el archivo convertido a pdf</returns>
        //public async Task<FileInfo> ConvertToPDFAsync(FileInfo file)
        private async Task<FileOutputDTO> ConvertToPDFAsync(FileInput Document)
        {
            try
            {
                FileInfo file = new FileInfo(Document.DocumentName);
                string pdfFileNameOriginal = file.Name.Replace(file.Extension, ".pdf");
                file = SaveFileToTempDirectory(file.FullName, Document.DocumentBase64);
                string pdfFileName = file.FullName.Replace(file.Extension, ".pdf");

                PdfExportOptions options = new()
                {
                    ImageQuality = PdfJpegImageQuality.Highest,
                    PdfUACompatibility = PdfUACompatibility.PdfUA1
                };

                using (Workbook xls = new Workbook())
                using (RichEditDocumentServer doc = new RichEditDocumentServer())
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open))
                {
                    switch (file.Extension)
                    {
                        case ".xlsx":
                            xls.LoadDocument(stream);
                            await xls.ExportToPdfAsync(pdfFileName);
                            break;

                        case ".xls":
                            xls.LoadDocument(stream);
                            await xls.ExportToPdfAsync(pdfFileName);
                            break;

                        case ".xlsb":
                            xls.LoadDocument(stream);
                            await xls.ExportToPdfAsync(pdfFileName);
                            break;

                        case ".docx":
                            doc.LoadDocument(stream);
                            await doc.ExportToPdfAsync(pdfFileName);
                            break;

                        case ".rtf":
                            doc.LoadDocument(stream);
                            await doc.ExportToPdfAsync(pdfFileName);
                            break;

                        case ".doc":
                            doc.LoadDocument(stream);
                            await doc.ExportToPdfAsync(pdfFileName);
                            break;
                        case ".pdf":
                            //file.MoveTo(pdfFileName);
                            break;
                        default:
                            break;
                            //throw new ArgumentOutOfRangeException(file.Extension, "File format not supported");
                    }
                    stream.Close();
                }

                FileOutputDTO fileOutput = new();
                FileInfo pdf = new(pdfFileName);
                PdfDocumentProcessor processor = new PdfDocumentProcessor();
                processor.LoadDocument(pdfFileName);
                Byte[] bytes = File.ReadAllBytes(pdf.FullName);                
                fileOutput.DocumentBase64 = bytes;
                fileOutput.NumberOfPages = processor.Document.Pages.Count;
                fileOutput.DocumentName = pdfFileNameOriginal; 
                return fileOutput;


            }
            catch (Exception ex)
            {
                //_logger.LogError($"{RemoteAgentExtensions.GetCallerName()}:\t{ex.Message}", ex);
            }
            return null;
        }

        /// <summary>
        /// Convierte a PDF archivos xlsx/docx
        /// </summary>
        /// <param name="file">FileInfo con el archivo a convertir.</param>
        /// <returns>el archivo convertido a pdf</returns>
        private FileOutputDTO ConvertToPDF(FileInput Document)
        {
            try
            {
                FileInfo file = new FileInfo(Document.DocumentName);
                string pdfFileNameOriginal = file.Name.Replace(file.Extension, ".pdf");
                file = SaveFileToTempDirectory(file.FullName, Document.DocumentBase64);
                string pdfFileName = file.FullName.Replace(file.Extension, ".pdf");

                PdfExportOptions options = new()
                {
                    ImageQuality = PdfJpegImageQuality.Highest,
                    PdfUACompatibility = PdfUACompatibility.PdfUA1
                };

                using (Workbook xls = new Workbook())
                using (RichEditDocumentServer doc = new RichEditDocumentServer())
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open))
                {
                    switch (file.Extension)
                    {
                        case ".xlsx":
                            xls.LoadDocument(stream);
                            xls.ExportToPdf(pdfFileName);
                            break;

                        case ".xls":
                            xls.LoadDocument(stream);
                            xls.ExportToPdf(pdfFileName);
                            break;

                        case ".xlsb":
                            xls.LoadDocument(stream);
                             xls.ExportToPdf(pdfFileName);
                            break;

                        case ".docx":
                            doc.LoadDocument(stream);
                             doc.ExportToPdf(pdfFileName);
                            break;

                        case ".rtf":
                            doc.LoadDocument(stream);
                             doc.ExportToPdf(pdfFileName);
                            break;

                        case ".doc":
                            doc.LoadDocument(stream);
                             doc.ExportToPdf(pdfFileName);
                            break;
                        case ".pdf":
                            //file.MoveTo(pdfFileName);
                            break;
                        default:
                            break;
                            //throw new ArgumentOutOfRangeException(file.Extension, "File format not supported");
                    }
                    stream.Close();
                }

                FileOutputDTO fileOutput = new();
                FileInfo pdf = new(pdfFileName);
                PdfDocumentProcessor processor = new PdfDocumentProcessor();
                processor.LoadDocument(pdfFileName);
                Byte[] bytes = File.ReadAllBytes(pdf.FullName);                
                fileOutput.DocumentBase64 = bytes;
                fileOutput.NumberOfPages = processor.Document.Pages.Count;
                fileOutput.DocumentName = pdfFileNameOriginal; 
                return fileOutput;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{RemoteAgentExtensions.GetCallerName()}:\t{ex.Message}", ex);
            }
            return null;
        }

        /// <summary>
        /// Convierte un archivo de texto plano en pdf
        /// </summary>
        /// <param name="fileInput, Documento"></param>
        /// <returns></returns>
        private FileOutputDTO ConvertTextToPDF(FileInput Document)
        {
            try
            {
                FileInfo file = new FileInfo(Document.DocumentName);
                string pdfFileNameOriginal = file.Name.Replace(file.Extension, ".pdf");
                file = SaveFileToTempDirectory(file.FullName, Document.DocumentBase64);
                string pdfFileName = file.FullName.Replace(file.Extension, ".pdf");

                // Create a Pdf Document Processor instance and load a PDF into it.
                PdfDocumentProcessor processor = new PdfDocumentProcessor();

                // Declare the PDF printer settings.
                PdfPrinterSettings pdfPrinterSettings = new PdfPrinterSettings();
                pdfPrinterSettings.PageOrientation = PdfPrintPageOrientation.Portrait;

                ////Specify .NET printer settings
                PrinterSettings printerSettings = pdfPrinterSettings.Settings;

                PdfCreationOptions options = new()
                {
                    Compatibility = PdfCompatibility.PdfA3b
                };

                processor.CreateEmptyDocument(pdfFileName, options);

                PdfGraphics graph = processor.CreateGraphics();
                using (Font font = new Font("Curier New", 10f))                    
                using (StreamReader reader = new StreamReader(file.FullName, true))
                {
                    SolidBrush black = (SolidBrush)Brushes.Black;
                    string line = string.Empty;
                    float linesPerPage = 0;
                    float yPosition = 0;
                    int count = 0;
                    float leftMargin = Convert.ToInt32(((0.5 * 10) / 25.4) * 100);
                    float topMargin = Convert.ToInt32(((1 * 10) / 25.4) * 100);
                    linesPerPage = ((float)PdfPaperSize.A4.Height) / font.GetHeight();

                    while (reader.Peek() > 0)
                    {
                        while (count < linesPerPage && ((line = reader.ReadLine()) != null))
                        {
                            yPosition = topMargin  + (count * font.GetHeight());
                            graph.DrawString(line, font, black, leftMargin, yPosition);
                            count++;
                        };
                        count = 0;yPosition = 0;
                        DevExpress.Pdf.PdfRectangle rec = new DevExpress.Pdf.PdfRectangle(0, 0, ((float)PdfPaperSize.A4.Width), ((float)PdfPaperSize.A4.Height));
                        processor.RenderNewPage(rec, graph);
                        graph = processor.CreateGraphics();
                    }

                    processor.SaveDocument(pdfFileName);
                }


                FileOutputDTO fileOutput = new();
                FileInfo pdf = new(pdfFileName);
                Byte[] bytes = File.ReadAllBytes(pdf.FullName);                
                fileOutput.DocumentBase64 = bytes;
                fileOutput.NumberOfPages = processor.Document.Pages.Count;
                fileOutput.DocumentName = pdfFileNameOriginal;
                return fileOutput;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{RemoteAgentExtensions.GetCallerName()}:\t{ex.Message}", ex);
            }
            return null;
        }

        public async Task<FileOutputDTO> ConvertToPDFService(FileInput Document)
        {
            FileOutputDTO fileOutput = new();

            if (Document.DocumentName != String.Empty)
            {
                if (Document.DocumentName.ToUpper().Contains("TXT"))
                {
                    fileOutput = ConvertTextToPDF(Document);
                }
                else
                {                    
                    fileOutput = ConvertToPDF(Document);
                }
            }

            return fileOutput;
        }
    }
}
