using System;

namespace CLMS.Users.Domain
{
    public class Entity
    {
        protected Entity ()
        {
            Id = new Guid ();
        }
        public Guid Id { get; private set; }
    }
}