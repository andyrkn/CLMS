using Autofac;
using CLMS.CoursesContentManagement.Business;
using CLMS.Kernel;

namespace CLMS.CoursesContentManagement.DependencyInjection
{
    public class AutofacIocContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDomainEvents(typeof(BusinessLayer).Assembly);
        }
    }
}