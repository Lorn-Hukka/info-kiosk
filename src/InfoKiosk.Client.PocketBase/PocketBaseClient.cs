namespace InfoKiosk.Client.PocketBase
{
    internal class PocketBaseClient: IClient
    {
        private readonly pocketbase_csharp_sdk.PocketBase _pocketBase;

        public PocketBaseClient(pocketbase_csharp_sdk.PocketBase pocketBase)
        {
            _pocketBase = pocketBase;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string path, CancellationToken token = default)
        {
            var result = await _pocketBase.Records.GetFullListAsync<T>(path, cancellationToken: token);
            
            if (result.IsFailed)
                throw new Exception("Cannot get...");

            return result.Value;
        }
    }
}