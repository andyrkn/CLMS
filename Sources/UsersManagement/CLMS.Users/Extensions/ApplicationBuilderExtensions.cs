using System;
using System.Linq;
using Autofac;
using CLMS.Users.Business;
using CLMS.Users.CrossCuttingConcerns;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.Users
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEventsHandlerForMessageBusEvents(this IApplicationBuilder builder)
        {
            var serviceProvider = builder.ApplicationServices;

            var messageBusListener = serviceProvider.GetService<IMessageBusListener>();
            var businessLayer = typeof(BusinessLayer).Assembly;
            var handlers = businessLayer.GetTypes().Where(x => x.IsClosedTypeOf(typeof(IDomainEventHandler<>)));
            foreach (var handler in handlers)
            {
                messageBusListener.ListenTo(handler.EventTypeFromEventHandler(), handler);
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