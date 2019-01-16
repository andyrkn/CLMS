﻿using CLMS.Kernel.Domain;

namespace CLMS.Notification.Domain.Entities
{
    public sealed class Subscription : Entity
    {
        public string Email { get; private set; }

        public static Subscription Create(string email)
        {
            return new Subscription
            {
                Email = email
            };
        }
    }
}