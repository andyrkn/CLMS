using AutoMapper;
using CLMS.Kernel;
using CLMS.QuestionsManagement.Business;
using CLMS.QuestionsManagement.Domain;
using CLMS.QuestionsManagement.Persistance;
using CLMS.QuestionsManagement.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.Questions
{
    public class Startup
    {
        private const string Policy = "Policy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<QuestionsContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Questions")));
            services.AddUsersAuthentication(Configuration);
            services.AddMediatR(typeof(BusinessLayer));
            services.AddAutoMapper(typeof(BusinessLayer));
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
           
            services.AddCors(config =>
            {
                config.AddPolicy(Policy, policy =>  
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(Policy);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
