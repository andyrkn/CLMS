using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CLMS.Users.CrossCuttingConcerns;
using CLMS.Users.Domain;
using CLMS.Users.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

        public static IServiceCollection AddUsersAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(
                        JwtBearerDefaults.AuthenticationScheme,
                        JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            return services;
        }

        public static IServiceCollection AddDomainEventsDispatcher(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBus, RabbitMqBus>();
            services.AddSingleton<IMessageBusListener, RabbitMqBusListener>();
            services.AddTransient<IDomainEventsDispatcher, DomainEventsDipatcher>();
            return services;
        }
    }
}