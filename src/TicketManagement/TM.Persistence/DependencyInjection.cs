using Microsoft.Extensions.DependencyInjection;
using TM.Domain.Interfaces;
using TM.Persistence.Repositories;

namespace TM.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<ITicketRepository, ITicketRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
