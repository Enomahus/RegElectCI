using Microsoft.AspNetCore.Identity;

namespace Infrastructures.Persistence.Entities
{
    public class RoleDao : IdentityRole<Guid>
    {
        public RoleDao() { }

        public RoleDao(string roleName)
            : base(roleName) { }
    }
}
