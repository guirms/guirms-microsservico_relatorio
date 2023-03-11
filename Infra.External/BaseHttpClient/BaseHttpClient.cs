using System.Text;
using System.Text.Json;

namespace Infra.External.HttpRepositoryBase
{
    public class BaseHttpClient : IBaseHttpClient, IDisposable
    {
        protected readonly HttpClient _httpClient;

        public BaseHttpClient()
        {
            _httpClient = new HttpClient() ?? throw new ArgumentNullException(nameof(_httpClient));
        }

        public async Task<HttpResponseMessage> PostJsonObjectAsync(string url, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            try
            {
                return await _httpClient.PostAsync(url, content);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Erro ao enviar webhook para {url}", ex);
            }
        }

        public async Task<HttpResponseMessage> PostByteReportAsync(string url, ByteArrayContent report)
        {
            try
            {
                return await _httpClient.PostAsync(url, report);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Erro ao enviar webhook para {url}", ex);
            }
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
