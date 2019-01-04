using Autofac;
using CLMS.Kernel;
using CLMS.Users.Business;
using Module = Autofac.Module;

namespace CLMS.Users.DependencyInjection
{
    public class AutofacIocContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDomainEvents(typeof(BusinessLayer).Assembly);
        }
    }
}
