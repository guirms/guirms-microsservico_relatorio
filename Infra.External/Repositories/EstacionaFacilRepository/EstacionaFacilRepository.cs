using Infra.External.HttpRepositoryBase;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Infra.External.Repositories.EstacionaFacilRepository
{
    public class EstacionaFacilRepository : BaseHttpClient, IEstacionaFacilRepository
    {
        private readonly string urlApi;

        public EstacionaFacilRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient) => urlApi = configuration["External:EstacionaFacilUrl"].GetSafeValue();

        public async Task<HttpResponseMessage> EnviarRelatorio(Document documento, MemoryStream memory)
        {
            var byteDocumento = new ByteArrayContent(memory.ToArray());

            if (byteDocumento != null)
                return await PostAsync(urlApi + "Usuario/Teste", byteDocumento);
            else
                throw new InvalidOperationException("O byte de documentos é nulo");
        }
    }
}
