using System;
using Autofac;
using CLMS.Kernel;
using CLMS.Notification.Business;

namespace CLMS.Notification.DependencyInjection
{
    public class AutofacIocContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDomainEvents(typeof(BusinessLayer).Assembly);
        }
    }
}
