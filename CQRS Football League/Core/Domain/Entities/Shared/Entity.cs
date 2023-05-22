using System.Runtime.Serialization;

namespace Core.Domain.Entities.Shared
{
    public abstract class Entity<T> : IEntity
    {
        public T Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; protected set; }

        protected Entity()
        {

        }

    }
}
