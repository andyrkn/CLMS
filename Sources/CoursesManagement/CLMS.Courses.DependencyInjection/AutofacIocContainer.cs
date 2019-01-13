using Autofac;
using CLMS.Courses.Business;
using CLMS.Kernel;

namespace CLMS.Courses.DependencyInjection
{
    public class AutofacIocContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDomainEvents(typeof(BusinessLayer).Assembly);
        }
    }
}
