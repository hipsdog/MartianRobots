using MartialRobots.Domain.Interfaces;
using MartialRobots.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialRobots.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the IGenericRepository 
    /// Contains the basic CRUD db operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc cref="IGenericRepository{T}" />
        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc cref="IGenericRepository{T}" />
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <inheritdoc cref="IGenericRepository{T}" />
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc cref="IGenericRepository{T}" />
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <inheritdoc cref="IGenericRepository{T}" />
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
