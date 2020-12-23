using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using qlogics.Kingdom_Ideas.Models;
using qlogics.Kingdom_Ideas.Repository;

namespace qlogics.Kingdom_Ideas.Manager
{
    public class Kingdom_IdeasManager : IInstallable, IPortable
    {
        private IKingdom_IdeasRepository _Kingdom_IdeasRepository;
        private ISqlRepository _sql;

        public Kingdom_IdeasManager(IKingdom_IdeasRepository Kingdom_IdeasRepository, ISqlRepository sql)
        {
            _Kingdom_IdeasRepository = Kingdom_IdeasRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "qlogics.Kingdom_Ideas." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "qlogics.Kingdom_Ideas.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Kingdom_Ideas> Kingdom_Ideass = _Kingdom_IdeasRepository.GetKingdom_Ideass(module.ModuleId).ToList();
            if (Kingdom_Ideass != null)
            {
                content = JsonSerializer.Serialize(Kingdom_Ideass);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Kingdom_Ideas> Kingdom_Ideass = null;
            if (!string.IsNullOrEmpty(content))
            {
                Kingdom_Ideass = JsonSerializer.Deserialize<List<Models.Kingdom_Ideas>>(content);
            }
            if (Kingdom_Ideass != null)
            {
                foreach(var Kingdom_Ideas in Kingdom_Ideass)
                {
                    _Kingdom_IdeasRepository.AddKingdom_Ideas(new Models.Kingdom_Ideas { ModuleId = module.ModuleId, Title = Kingdom_Ideas.Title });
                }
            }
        }
    }
}