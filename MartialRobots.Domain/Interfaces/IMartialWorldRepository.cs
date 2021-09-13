using MartialRobots.Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartialRobots.Domain.Interfaces
{
    /// <summary>
    /// Interface for the martial world operations
    /// </summary>
    public interface IMartialWorldRepository : IGenericRepository<MartialWorldEntity>
    {
        /// <summary>
        /// Get the last 10 execution results
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MartialWorldEntity>> GetLastTenMartialWorlds();
    }
}
