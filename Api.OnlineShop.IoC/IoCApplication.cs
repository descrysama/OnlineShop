using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Repository;
using Api.OnlineShop.Datas.Repository.Contract;
using Api.OnlineShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Api.OnlineShop.IoC
{
    public static class IoCApplication
    {

        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }


        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {

            services.AddScoped<UserService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<OnlineShopDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }

    }
}

