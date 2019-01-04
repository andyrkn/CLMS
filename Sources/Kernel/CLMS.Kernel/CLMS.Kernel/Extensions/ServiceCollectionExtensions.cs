using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CLMS.Kernel
{
    public static class ServiceCollectionExtensions
    {
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
                    var validIssuer = configuration["Jwt:Issuer"];
                    var validAudience = configuration["Jwt:Audience"];
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = validIssuer,
                        ValidAudience = validAudience,
                        IssuerSigningKey = symmetricSecurityKey
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

        public static IServiceCollection AddMessageBusForDomainEvents(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBus, RabbitMqBus>();
            services.AddSingleton<IMessageBusListener, RabbitMqBusListener>();
            services.AddTransient<IDomainEventsDispatcher, DomainEventsDipatcher>();
            services.AddScoped<IDependencyScope, AutofacDependencyScope>();

            return services;
        }
    }
}