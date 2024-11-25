using System;
using System.Text;

namespace PDFGeneratorPOC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string[] inputFiles = { "PdfGenerator\\InputPdf\\Report_25_11_2024 11_44_30 am.pdf" ,"PdfGenerator\\InputPdf\\Report_25_11_2024 11_43_21 am.pdf"};
                string outputFile = "PdfGenerator\\OutputPdf\\merged.pdf"; 
                PdfMerger merger = new PdfMerger();
                merger.MergePdfs(inputFiles, outputFile);
                Console.WriteLine("PDFs merged successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("PDFs merged Failed!");
                Console.WriteLine(ex.ToString());
                throw;
            }
       
        }
    }
}
