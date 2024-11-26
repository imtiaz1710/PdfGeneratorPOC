using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

                string inputPDFDir = Path.Combine(projectDir, "PdfGenerator", "InputPdf");
                string outputPDFDir = Path.Combine(projectDir, "PdfGenerator", "OutputPdf");

                if (!Directory.Exists(outputPDFDir))
                {
                    Directory.CreateDirectory(outputPDFDir);
                }

                var inputFilePath = Path.Combine(projectDir, "input.txt");
                var fileNames = new List<string>(File.ReadAllLines(inputFilePath));

                var pdfInputFullFilePaths = new List<string>();

                foreach (var fileName in fileNames)
                {
                    pdfInputFullFilePaths.Add(Path.Combine(inputPDFDir, fileName));
                }

                string outputFile = Path.Combine(outputPDFDir, "merged.pdf");

                PdfMerger merger = new PdfMerger();
                merger.MergePdfs(pdfInputFullFilePaths, outputFile);
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
