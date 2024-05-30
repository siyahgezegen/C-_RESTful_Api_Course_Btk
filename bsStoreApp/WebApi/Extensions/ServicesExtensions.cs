using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        // Repository Servisinin eklenmesi
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        
        // Service'ın eklenmesi
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServicesManager, ServicesManager>();
        
        
        // Logger Servisinin eklenmesi
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();


    }
}
