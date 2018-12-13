using CLMS.Users.Business;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseMiddleware<JwtMiddleware>();
            app.UseCors(UsersPolicy);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}