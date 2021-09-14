﻿using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Context;
using System;

namespace MartianRobots.Infrastructure.Repositories
{
    /// <summary>
    /// Unit of work: centralize database operations
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMartianWorldRepository MartianWorlds { get; }

        /// <summary>
        /// UnitOfWork constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="martianWorld"></param>
        public UnitOfWork(ApplicationDbContext dbContext, IMartianWorldRepository martianWorld)
        {
            this._context = dbContext;
            this.MartianWorlds = martianWorld;
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
