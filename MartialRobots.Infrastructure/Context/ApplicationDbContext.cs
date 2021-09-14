using MartialRobots.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MartialRobots.Infrastructure.Context
{
    /// <summary>
    /// EntityFramework context to query from database
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

        public DbSet<MartialWorldEntity> MartialWorlds { get; set; }
    }

    /// <summary>
    /// Class to bypass the other ways of creating the DbContext and use the design-time factory instead
    /// without it, the designer will search for CreateHostBuilder
    /// </summary>
    public class MyDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var parentPath = Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString();
            var newPath = Path.Combine(parentPath, "MartialRobots");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(newPath.ToString())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("DevConnection");

            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }

}
