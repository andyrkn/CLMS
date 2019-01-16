using Autofac;
using CLMS.Kernel;
using CLMS.Notification.Business;
using CLMS.Notification.DependencyInjection;
using CLMS.Notification.Domain;
using CLMS.Notification.Domain.Repository;
using CLMS.Notification.Email;
using CLMS.Notification.Persistance;
using CLMS.Notification.Persistance.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

namespace CLMS.Notification
{
    public class Startup
    {
        private const string Policy = "Policy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddUsersAuthentication(Configuration);
            services.AddMessageBusForDomainEvents();
            services.AddDbContext<NotificationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Notification")));
            services.AddMediatR(typeof(BusinessLayer));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddSingleton<IEmailService, EmailService>();

            services.AddCors(config =>
            {
                config.AddPolicy(Policy, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddSingleton(Configuration.GetSection(nameof(EmailOptions)).Get<EmailOptions>());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacIocContainer>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(Policy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMessageBusForDomainEvents(typeof(BusinessLayer).Assembly);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}