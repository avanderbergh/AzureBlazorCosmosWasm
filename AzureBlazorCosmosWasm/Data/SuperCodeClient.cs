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

        public async Task<SuperCodeContext> GetDbContextAsync()
        {
            _credentials ??= await _tokenClient.GetTokenAsync();

            SuperCodeContext context = null;

            // use a delegate to always resolve late (no caching)
            CosmosToken getCredentials() => _credentials;

            // configure EF Core to use Cosmos DB
            var options = new DbContextOptionsBuilder<SuperCodeContext>()
                .UseCosmos(getCredentials().Endpoint,
                    getCredentials().Key,
                    Context.SuperCode,
                opt =>
                 opt.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Gateway));

            try
            {
                // if credentials are stale this will fail
                context = new SuperCodeContext(options.Options);
            }
            catch
            {
                // try again with fresh credentials
                _credentials = await _tokenClient.GetTokenAsync();
                context = new SuperCodeContext(options.Options);
            }

            // give what we got
            return context;
        }
    }
}
