using Infra.External.HttpRepositoryBase;
using iText.Kernel.Pdf;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Infra.External.Repositories.EstacionaFacilRepository
{
    public class EstacionaFacilRepository : BaseHttpClient, IEstacionaFacilRepository
    {
        private readonly IConfiguration _configuration;

        public EstacionaFacilRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient)
        {
            _configuration = configuration;
        }

        public async Task EnviarRelatorio(PdfDocument? pdfDocument)
        {
            var model = new PdfModel
            {
                Content = pdfDocument.GetPage(1).GetContentBytes()
            };

            var jsonContent = JsonSerializer.Serialize(model);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync(_configuration["External:EstacionaFacilUrl"] + "Usuario/Teste", httpContent);
        }

        public class PdfModel
        {
            public byte[] Content { get; set; }
        }
    }
}
