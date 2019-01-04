using System;
using CLMS.Users.Domain;
using CLMS.Users.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLMS.Users
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Users")));
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.SignIn.RequireConfirmedEmail = false;
                    config.Password.RequireDigit = true;
                    config.Password.RequireLowercase = true;
                    config.Password.RequireNonAlphanumeric = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<UsersContext>();
            services.AddScoped<IUserManger, UserManager>();

            return services;
        }
    }
}