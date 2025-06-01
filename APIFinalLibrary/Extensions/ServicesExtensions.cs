using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using System.Text;

namespace APIFinalLibrary.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();
        public static void ConfigureLogEntryService(this IServiceCollection services) => services.AddScoped<ILogEntryService, LogEntryManager>();
        public static void ConfigureTokenService(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureJwt(configuration);
            services.AddScoped<ITokenService, TokenManager>();
        }
    }
}
