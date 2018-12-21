using System;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IMessageBusListener
    {
        void ListenTo<TDomainEvent>()
            where TDomainEvent : class, IDomainEvent;

        void ListenTo(Type eventType, Type eventHandlerType);
    }
}