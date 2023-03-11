using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
namespace Application.Reports.RelatorioGeral
{
    public class RelatorioGeral: IRelatorioGeral
    {
        public Document GerarRelatorioGeral(MemoryStream memory)
        {
            var pdf = new PdfDocument(new PdfWriter(memory));
            var documento = new Document(pdf);

            documento.Add(new Paragraph("Este é um documento PDF gerado com iText7. rubi"));
            documento.Close();

            return documento;
        }
    }
}
