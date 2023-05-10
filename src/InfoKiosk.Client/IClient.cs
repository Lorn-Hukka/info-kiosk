namespace InfoKiosk.Client
{
    public interface IClient
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string path, CancellationToken token = default);
    }
}