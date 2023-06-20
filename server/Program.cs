global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using Signify.Models;
global using server.Data;
global using Microsoft.Extensions.DependencyInjection;
global using server.DTOClasses;
global using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using server.Configuration;
using MediatR;
using Microsoft.Identity.Client;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Diagnostics;
using server.CustomFilters;

public class Program {
       public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services
            .AddAutoMapper(typeof(Program).Assembly)
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddResponseCaching(x => x.MaximumBodySize = 1024)
            .AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new MySampleFilterAttribute("Global Level", 11));
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters();


            builder.Services
                .AddAuthenticationDP(builder.Configuration)
                .AddDbContextUtil(builder.Configuration)
                .AddCorsUtil()
                .AddServicesUtil();


            builder.Services.AddMediatR(typeof(Program));

            var app = builder.Build();

        //Configure the HTTP request pipeline.
            app.ConfigureExceptions();

            app.UseCors("EnableCORS"); 


            /* Response Caching should always be after the use cors middleware and it only works for
             http get methods */
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10) 
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] {"Accept-Encoding"};
                await next();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
       }
}
