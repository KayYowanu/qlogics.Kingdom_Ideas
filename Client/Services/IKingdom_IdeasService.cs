using System.Collections.Generic;
using System.Threading.Tasks;
using qlogics.Kingdom_Ideas.Models;

namespace qlogics.Kingdom_Ideas.Services
{
    public interface IKingdom_IdeasService 
    {
        Task<List<Models.Kingdom_Ideas>> GetKingdom_IdeassAsync(int ModuleId);

        Task<Models.Kingdom_Ideas> GetKingdom_IdeasAsync(int Kingdom_IdeasId, int ModuleId);

        Task<Models.Kingdom_Ideas> AddKingdom_IdeasAsync(Models.Kingdom_Ideas Kingdom_Ideas);

        Task<Models.Kingdom_Ideas> UpdateKingdom_IdeasAsync(Models.Kingdom_Ideas Kingdom_Ideas);

        Task DeleteKingdom_IdeasAsync(int Kingdom_IdeasId, int ModuleId);
    }
}
