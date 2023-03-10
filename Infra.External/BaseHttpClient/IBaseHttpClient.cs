namespace Infra.External.HttpRepositoryBase
{
    public interface IBaseHttpClient
    {
        Task PostAsync(string url, object data);
    }
}
