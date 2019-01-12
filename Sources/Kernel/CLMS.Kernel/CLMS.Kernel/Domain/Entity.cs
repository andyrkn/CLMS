using System;

namespace CLMS.Kernel.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}