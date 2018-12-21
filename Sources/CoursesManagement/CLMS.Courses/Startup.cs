using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CLMS.Courses.Business;
using MediatR;
using AutoMapper;
using CLMS.Courses.Persistance.Repositories;
using CLMS.Courses.Domain;
using CLMS.Courses.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Courses
{
    public class Startup
    {
        private const string CoursesPolicy = "CoursesPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoursesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Courses")));
            services.AddAutoMapper(typeof(BusinessLayer).Assembly);
            services.AddMediatR(typeof(BusinessLayer).Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });
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

            app.UseCors(CoursesPolicy);
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
