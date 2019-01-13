using Autofac;
using AutoMapper;
using CLMS.CoursesContentManagement.Business;
using CLMS.CoursesContentManagement.DependencyInjection;
using CLMS.CoursesContentManagement.Domain;
using CLMS.CoursesContentManagement.Persistance;
using CLMS.Kernel;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.CoursesContentManagement
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
            services.AddDbContext<ContentContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Content")));
            services.AddUsersAuthentication(Configuration);

            services.AddMediatR(typeof(BusinessLayer));
            services.AddCors(config =>
            {
                config.AddPolicy(Policy, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddAutoMapper(typeof(BusinessLayer).Assembly);
            services.AddScoped<IContentHolderRepository, ContentHolderRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddMessageBusForDomainEvents();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacIocContainer>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(Policy);
            app.UseHttpsRedirection();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMessageBusForDomainEvents(typeof(BusinessLayer).Assembly);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();

        }
    }
}