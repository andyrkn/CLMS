using Autofac;
using CLMS.Users.Business;
using CLMS.Users.CrossCuttingConcerns;

namespace CLMS.Users.DependencyInjection
{
    public class AutofacIocContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BusinessLayer).Assembly)
                .Where(candidate => candidate.IsClosedTypeOf(typeof(IDomainEventHandler<>)))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AutofacDependencyScope>()
                .As<IDependencyScope>()
                .InstancePerLifetimeScope();
        }
    }
}
