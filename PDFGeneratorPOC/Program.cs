using System;
using System.IO;
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

                string baseDir = AppContext.BaseDirectory;

                string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;

                string inputDir = Path.Combine(projectDir, "PdfGenerator", "InputPdf");

                string outputDir = Path.Combine(projectDir, "PdfGenerator", "OutputPdf");

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                string[] inputFiles = { 
                    Path.Combine(inputDir, "Report_25_11_2024 11_44_30 am.pdf"), 
                    Path.Combine(inputDir, "Report_25_11_2024 11_43_21 am.pdf") 
                }; 

                string outputFile = Path.Combine(outputDir, "merged.pdf");

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
