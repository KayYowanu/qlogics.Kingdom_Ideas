using Oqtane.Models;
using Oqtane.Modules;

namespace qlogics.Kingdom_Ideas
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Kingdom_Ideas",
            Description = "Kingdom_Ideas",
            Version = "1.0.0",
            ServerManagerType = "qlogics.Kingdom_Ideas.Manager.Kingdom_IdeasManager, qlogics.Kingdom_Ideas.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "qlogics.Kingdom_Ideas.Shared.Oqtane"
        };
    }
}
