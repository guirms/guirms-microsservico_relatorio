using iText.Layout;

namespace Infra.External.Repositories.EstacionaFacilRepository
{
    public interface IEstacionaFacilRepository
    {
        Task<HttpResponseMessage> EnviarRelatorio(Document documento, MemoryStream memory);
    }
}
