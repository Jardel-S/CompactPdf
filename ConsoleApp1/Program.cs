using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"C:\CompactPdf\pkpadmin,+840-4082-1-CE.pdf";
            string outputFile = @"C:\CompactPdf\arquivo_compactado.pdf";

            // Cria um novo documento PDF
            Document document = new Document();

            // Cria um objeto PdfCopy com o documento e o arquivo de saída
            PdfCopy copy = new PdfCopy(document, new FileStream(outputFile, FileMode.Create));

            // Abre o documento
            document.Open();

            // Abre o arquivo de entrada
            PdfReader reader = new PdfReader(inputFile);

            // Itera sobre todas as páginas do arquivo de entrada
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                // Obtém a página atual
                PdfImportedPage page = copy.GetImportedPage(reader, i);

                // Adiciona a página ao documento de saída
                copy.AddPage(page);
            }

            // Fecha o documento de saída
            document.Close();

            Console.WriteLine("Arquivo compactado criado com sucesso!");
        }
    }
}
