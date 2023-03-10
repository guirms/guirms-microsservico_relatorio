using iText.Kernel.Pdf;

namespace Infra.External.Repositories.EstacionaFacilRepository
{
    public interface IEstacionaFacilRepository
    {
        Task EnviarRelatorio(PdfDocument? pdfDocument);
    }
}
