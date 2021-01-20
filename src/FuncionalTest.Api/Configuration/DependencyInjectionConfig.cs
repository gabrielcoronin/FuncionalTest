using FuncionalTest.Data.Context;
using FuncionalTest.Data.Repository;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FuncionalTest.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();          

            return services;
        }
    }
}
