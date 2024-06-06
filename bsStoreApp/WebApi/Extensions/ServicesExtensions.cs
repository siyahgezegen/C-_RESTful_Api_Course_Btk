using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        // Repository Servisinin eklenmesi
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        // IoT Scoped işlemi
        // IServiceManager sınıfı artık Services manager sınıfının metodlarını içeriyor yani
        // Constractor üzerinden IServiceManager'ı her talep ettiğimde bana 1 adet ServiceManager nesnesi üretecek.
        // ben bu IServiceManager üzerinden ilgili nesnenin propertylerine/metodlarına uğlaşabileceğim
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServicesManager, ServicesManager>();


        // Logger Servisinin eklenmesi
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader().WithExposedHeaders("X-Pagination")
            );
            });

    }
}
