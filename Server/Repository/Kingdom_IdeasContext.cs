using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using qlogics.Kingdom_Ideas.Models;

namespace qlogics.Kingdom_Ideas.Repository
{
    public class Kingdom_IdeasContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Kingdom_Ideas> Kingdom_Ideas { get; set; }

        public Kingdom_IdeasContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
