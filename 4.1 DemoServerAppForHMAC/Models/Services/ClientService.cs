using DemoServerAppForHMAC.Context;
using Microsoft.EntityFrameworkCore;

namespace DemoServerAppForHMAC.Models.Services
{
    public class ClientService
    {
        private readonly ServerAppDbContext _serverAppDbContext;
        public ClientService(ServerAppDbContext serverAppDbContext) {

            _serverAppDbContext = serverAppDbContext;
        }

        public async Task<string> GetClientSecrectKeyInfoAsync(string clientId)
        {
                var client =  _serverAppDbContext.ClientInfos
                .AsNoTracking()
                .FirstOrDefault(client => client.ClientId == clientId);

            return client?.ClientSecretKey;
        }
    }
}
