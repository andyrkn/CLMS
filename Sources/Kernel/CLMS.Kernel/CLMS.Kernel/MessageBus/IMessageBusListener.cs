using System;

namespace CLMS.Kernel
{
    internal interface IMessageBusListener
    {
        void ListenTo(Type eventType, Type eventHandlerType);
    }
}