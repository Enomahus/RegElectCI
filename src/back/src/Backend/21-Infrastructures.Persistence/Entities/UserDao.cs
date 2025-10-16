using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Persistence.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructures.Persistence.Entities
{
    public class UserDao : IdentityUser<Guid>, IEntityBaseDao<Guid>, ITimestampedEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<RefreshTokenDao> RefreshTokens { get; set; } = [];
        public virtual ICollection<UserRoleDao> UserRoles { get; set; } = [];

        public DateTimeOffset? DisabledDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
