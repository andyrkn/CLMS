using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CLMS.Users.Business;
using CLMS.Users.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.Users
{
    public class Startup
    {
        private const string UsersPolicy = "UsersPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfig(Configuration);
            services.AddMediatR(typeof(BusinessLayer).Assembly);
            services.AddUsersAuthentication(Configuration);
            services.AddCors(config =>
            {
                config.AddPolicy(UsersPolicy, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddTransient<JwtProvider>();
            services.AddDomainEventsDispatcher();

            services.AddSingleton(_ => Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacIocContainer>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseEventsHandlerForMessageBusEvents();
            app.UseMiddleware<JwtMiddleware>();
            app.UseCors(UsersPolicy);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}