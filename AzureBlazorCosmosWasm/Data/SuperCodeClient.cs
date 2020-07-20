using SuperCodeData;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AzureBlazorCosmosWasm.Data
{
 
    public class SuperCodeClient
    {
        private CosmosToken _credentials;

        private readonly TokenClient _tokenClient;

        public SuperCodeClient(TokenClient tokenClient)
        {
            _tokenClient = tokenClient;
        }

        public async Task<LocationContext> GetDbContextAsync()
        {
            _credentials ??= await _tokenClient.GetTokenAsync();

            LocationContext context = null;

            // use a delegate to always resolve late (no caching)
            CosmosToken getCredentials() => _credentials;

            // configure EF Core to use Cosmos DB
            var options = new DbContextOptionsBuilder<LocationContext>()
                .UseCosmos(getCredentials().Endpoint,
                    getCredentials().Key,
                    Context.SuperCode,
                opt =>
                 opt.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Gateway));

            try
            {
                // if credentials are stale this will fail
                context = new LocationContext(options.Options);
            }
            catch
            {
                // try again with fresh credentials
                _credentials = await _tokenClient.GetTokenAsync();
                context = new LocationContext(options.Options);
            }

            // give what we got
            return context;
        }
    }
}
