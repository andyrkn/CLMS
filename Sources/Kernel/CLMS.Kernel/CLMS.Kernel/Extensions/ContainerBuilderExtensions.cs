using System.Reflection;
using Autofac;

namespace CLMS.Kernel
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterDomainEvents(this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            builder.RegisterAssemblyTypes(assemblies)
                .Where(candidate => candidate.IsClosedTypeOf(typeof(IDomainEventHandler<>)))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}