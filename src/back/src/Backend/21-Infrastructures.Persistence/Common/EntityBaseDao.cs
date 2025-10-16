using System.ComponentModel.DataAnnotations;

namespace Infrastructures.Persistence.Common
{
    public class EntityBaseDao<T> : IEntityBaseDao<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
