using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.Kernel
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMessageBusForDomainEvents(this IApplicationBuilder builder, params Assembly[] assemblies)
        {
            var serviceProvider = builder.ApplicationServices;
            var messageBusListener = serviceProvider.GetService<IMessageBusListener>();

            foreach (var assembly in assemblies)
            {
                var handlers = assembly.GetTypes().Where(x => x.IsClosedTypeOf(typeof(IDomainEventHandler<>)));
                foreach (var handler in handlers)
                {
                    messageBusListener.ListenTo(handler.EventTypeFromEventHandler(), handler);
                }
            }

            return builder;
        }

        private static Type EventTypeFromEventHandler(this Type eventHandlerType)
        {
            // TODO: this works only when handler implements directly IDomainEventHandler<> fix it
            return eventHandlerType.GetInterfaces()[0].GetGenericArguments()[0];
        }
    }
}