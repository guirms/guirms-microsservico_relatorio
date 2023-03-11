namespace Infra.External.HttpRepositoryBase
{
    public interface IBaseHttpClient
    {
        Task<HttpResponseMessage> PostAsync(string url, object data);
    }
}
