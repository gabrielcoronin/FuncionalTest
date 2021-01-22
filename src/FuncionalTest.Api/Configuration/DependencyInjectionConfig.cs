using FuncionalTest.Api.GraphQL;
using FuncionalTest.Api.GraphQL.Mutations;
using FuncionalTest.Api.GraphQL.Queries;
using FuncionalTest.Api.GraphQL.Types;
using FuncionalTest.Data.GraphQL.Repositories;
using FuncionalTest.Data.REST.Context;
using FuncionalTest.Data.REST.Repository;
using FuncionalTest.Domain.REST.Interfaces.IRepositories;
using FuncionalTest.Domain.REST.Interfaces.IServices;
using FuncionalTest.Domain.REST.Services;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FuncionalTest.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddTransient<Repository, Repository>();
            services.AddScoped<AccountSchema>();
            services.AddScoped<AccountQuery>();
            services.AddScoped<AccountMutation>();
            services.AddScoped<AccountType>();
            services.AddScoped<AccountInputType>();


            return services;
        }
    }
}
