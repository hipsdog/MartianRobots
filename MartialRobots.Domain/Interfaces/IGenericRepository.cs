using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartialRobots.Domain.Interfaces
{
    /// <summary>
    /// Helps us to save and retrieve its persistent state from the database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get entity with a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        Task<T> Get(int id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Add(T entity);

        /// <summary>
        /// Deletes a given entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Updates a given entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
