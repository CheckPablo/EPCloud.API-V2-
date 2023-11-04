using Aspose.Words;

namespace Microsoft.AspNetCore.Http
{
    internal static class IFormFileExtensions
    {
        //public static byte[] ConvertToPdf(this IFormFile wordFile)
        //{
        //    // Check the file extension
        //    string fileExtension = Path.GetExtension(wordFile.FileName);
        //    if (!string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase) &&
        //        !string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
        //    {
        //        throw new ArgumentException("Invalid file type. Only Word documents (.doc, .docx) are supported.");
        //    }

        //    // Create a temporary file path for the Word document
        //    string tempFilePath = Path.GetTempFileName();

        //    // Save the uploaded Word document to the temporary file path
        //    using (FileStream stream = new FileStream(tempFilePath, FileMode.Create))
        //    {
        //        wordFile.CopyTo(stream);
        //    }

        //    // Initialize Word application
        //    var wordApplication = new Microsoft.Office.Interop.Word.Application();

        //    // Open the Word document
        //    var wordDocument = wordApplication.Documents.Open(tempFilePath);

        //    // Save the Word document as PDF to a memory stream
        //    MemoryStream pdfStream = new MemoryStream();
        //    wordDocument.SaveAs(pdfStream, WdSaveFormat.wdFormatPDF);

        //    // Close the Word document and application
        //    wordDocument.Close();
        //    wordApplication.Quit();

        //    // Delete the temporary Word document file
        //    File.Delete(tempFilePath);

        //    // Return the PDF document as a byte array
        //    return pdfStream.ToArray();
        //}

        public static byte[] ConvertToPdf(this IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var document = new Document(stream);

                using (var output = new MemoryStream())
                {
                    document.Save(output, SaveFormat.Pdf);
                    //Document pdfDoc = new Document(ArtifactsDir + "PDF2Word.ConvertPdfToDocx.pdf");
                    return output.ToArray();
                }
            }
        }

        public static byte[] ToByteArray(this IFormFile file, string? extension = null) 
        {
            if (extension is not null)
            {
                // Check if the file is a PDF
                string fileExtension = Path.GetExtension(file.FileName);
                if (!string.Equals(fileExtension, extension, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException($"Invalid file type. Only {extension} files are supported.");
                }
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Copy the uploaded file to the memory stream
                file.CopyTo(memoryStream);

                // Return the file content as a byte array
                return memoryStream.ToArray();
            }
        }
    }
}
