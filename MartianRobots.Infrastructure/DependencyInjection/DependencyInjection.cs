using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Context;
using MartianRobots.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MartianRobots.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Static class called from the user app to inject the domain dependencies
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string dbConnection)
        {
            services.AddTransient<IMartianWorldRepository, MartianWorldRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(dbConnection, 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }
    }
}
