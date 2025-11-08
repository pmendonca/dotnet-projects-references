using Mediatr.Example.src.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mediatr.Example.src.BuildingBlocks.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connString)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connString));
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IDomainEventDispatcher, EfDomainEventDispatcher>();
            return services;
        }
    }
}
