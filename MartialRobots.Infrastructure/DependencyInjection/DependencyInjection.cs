using MartialRobots.Domain.Interfaces;
using MartialRobots.Infrastructure.Context;
using MartialRobots.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MartialRobots.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Static class called from the user app to inject the domain dependencies
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string dbConnection)
        {
            services.AddTransient<IMartialWorldRepository, MartialWorldRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(dbConnection, 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }
    }
}
