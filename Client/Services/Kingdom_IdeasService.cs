using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using qlogics.Kingdom_Ideas.Models;

namespace qlogics.Kingdom_Ideas.Services
{
    public class Kingdom_IdeasService : ServiceBase, IKingdom_IdeasService, IService
    {
        private readonly SiteState _siteState;

        public Kingdom_IdeasService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "Kingdom_Ideas");

        public async Task<List<Models.Kingdom_Ideas>> GetKingdom_IdeassAsync(int ModuleId)
        {
            List<Models.Kingdom_Ideas> Kingdom_Ideass = await GetJsonAsync<List<Models.Kingdom_Ideas>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Kingdom_Ideass.OrderBy(item => item.Title).ToList();
        }

        public async Task<Models.Kingdom_Ideas> GetKingdom_IdeasAsync(int Kingdom_IdeasId, int ModuleId)
        {
            return await GetJsonAsync<Models.Kingdom_Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Kingdom_IdeasId}", ModuleId));
        }

        public async Task<Models.Kingdom_Ideas> AddKingdom_IdeasAsync(Models.Kingdom_Ideas Kingdom_Ideas)
        {
            return await PostJsonAsync<Models.Kingdom_Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}", Kingdom_Ideas.ModuleId), Kingdom_Ideas);
        }

        public async Task<Models.Kingdom_Ideas> UpdateKingdom_IdeasAsync(Models.Kingdom_Ideas Kingdom_Ideas)
        {
            return await PutJsonAsync<Models.Kingdom_Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Kingdom_Ideas.Kingdom_IdeasId}", Kingdom_Ideas.ModuleId), Kingdom_Ideas);
        }

        public async Task DeleteKingdom_IdeasAsync(int Kingdom_IdeasId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{Kingdom_IdeasId}", ModuleId));
        }
    }
}
