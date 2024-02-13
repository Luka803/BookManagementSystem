using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Persistence.DataBaseContext;
using BookManagementSystem.Persistence.Repositories;
using BookManagementSystem.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSystem.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<BookManagementSystemDbContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("DesktopConnString"));
        });
        services.AddTransient<IApplicationUnitOfWorkRepository, ApplicationUnitOfWork>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
