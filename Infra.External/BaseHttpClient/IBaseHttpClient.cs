namespace Infra.External.HttpRepositoryBase
{
    public interface IBaseHttpClient
    {
        Task<HttpResponseMessage> PostJsonObjectAsync(string url, object data);
        Task<HttpResponseMessage> PostByteReportAsync(string url, ByteArrayContent data);
    }
}
