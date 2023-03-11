using System.Text;
using System.Text.Json;

namespace Infra.External.HttpRepositoryBase
{
    public class BaseHttpClient : IBaseHttpClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public BaseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> PostAsync(string metodo, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            try
            {
                return await _httpClient.PostAsync(metodo, content);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Erro ao enviar webhook para {metodo}", ex);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
