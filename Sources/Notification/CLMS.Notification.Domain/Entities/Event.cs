using System;
using System.Collections.Generic;
using System.Linq;
using CLMS.Kernel.Domain;
using CSharpFunctionalExtensions;

namespace CLMS.Notification.Domain.Entities
{
    public sealed class Event : Entity
    {
        private ICollection<Subscription> subscriptions = new List<Subscription>();

        private Event()
        {
        }

        public Guid OriginId { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Subscription> Subscriptions
        {
            get => subscriptions;
            private set => subscriptions = value.ToList();
        }

        public static Event Create(Guid originId, string name)
        {
            return new Event {OriginId = originId, Name = name};
        }

        public void Subscribe(string email)
        {
            var newSubscribtion = Subscription.Create(email);
            subscriptions.Add(newSubscribtion);
        }

        public Result Unsubscribe(string email)
        {
            Maybe<Subscription> subscriptionToRemove = subscriptions.FirstOrDefault(x => x.Email == email);

            return subscriptionToRemove.ToResult("Subscription not found")
                .OnSuccess(x => subscriptions.Remove(x));
        }
    }
}