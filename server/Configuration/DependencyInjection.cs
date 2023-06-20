using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using server.Utility.ApiResponse;
using server.Utility.ApiRoute;
using server.Utility.Logger;
using System.Text;

namespace server.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationDP(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "https://localhost:7100",
                    ValidAudience = "https://localhost:7100",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("SecretKey:MySecretKey")))
                };
            });
            return services;
        }

        public static IServiceCollection AddDbContextUtil(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            });

            return services;
        }

        public static IServiceCollection AddCorsUtil(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            return services;
        }


        public static IServiceCollection AddServicesUtil(this IServiceCollection services)
        {
            //services.AddScoped<IGetApiRoute, GetApiRoute>();
            //.AddXmlDataContractSerializerFormatters();
            services.AddScoped<ILoggerManager, LoggerManager>();
            return services;
        }


        public static IServiceCollection InjectDependenciesUtil(this IServiceCollection services)
        {
            services.AddScoped<IResponse, Response>();
            return services;
        }
    }
}
