using MartialRobots.Domain.Interfaces;
using MartialRobots.Infrastructure.Context;
using System;

namespace MartialRobots.Infrastructure.Repositories
{
    /// <summary>
    /// Unit of work: centralize database operations
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMartialWorldRepository MartialWorlds { get; }

        /// <summary>
        /// UnitOfWork constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="martialWorld"></param>
        public UnitOfWork(ApplicationDbContext dbContext, IMartialWorldRepository martialWorld)
        {
            this._context = dbContext;
            this.MartialWorlds = martialWorld;
        }

        /// <inheritdoc cref="IUnitOfWork" />
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
