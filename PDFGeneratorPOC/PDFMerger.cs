using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace PDFGeneratorPOC
{
    public class PdfMerger
    {
        public void MergePdfs(string[] fileNames, string outputFileName)
        {
            using (PdfDocument outputDocument = new PdfDocument())
            {
                foreach (string file in fileNames)
                {
                    using (PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
                    {
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            PdfPage page = inputDocument.Pages[idx];
                            outputDocument.AddPage(page);
                        }
                    }
                }
                outputDocument.Save(outputFileName);
            }
        }
    }

}
