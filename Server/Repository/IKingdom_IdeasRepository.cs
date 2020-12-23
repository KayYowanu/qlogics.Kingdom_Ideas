using System.Collections.Generic;
using qlogics.Kingdom_Ideas.Models;

namespace qlogics.Kingdom_Ideas.Repository
{
    public interface IKingdom_IdeasRepository
    {
        IEnumerable<Models.Kingdom_Ideas> GetKingdom_Ideass(int ModuleId);
        Models.Kingdom_Ideas GetKingdom_Ideas(int Kingdom_IdeasId);
        Models.Kingdom_Ideas AddKingdom_Ideas(Models.Kingdom_Ideas Kingdom_Ideas);
        Models.Kingdom_Ideas UpdateKingdom_Ideas(Models.Kingdom_Ideas Kingdom_Ideas);
        void DeleteKingdom_Ideas(int Kingdom_IdeasId);
    }
}
