using BookManagementSystem.Application.Contracts.Caching.Base;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Infrastructure.Caching;
using BookManagementSystem.Infrastructure.Logging;
using BookManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IApplicationUnitOfWorkCache, ApplicationUnitOfWorkCache>();
            services.AddScoped(typeof(IGenericMemoryCacheService<>), typeof(MemoryCacheService<>));
            return services;
        }

    }
}
