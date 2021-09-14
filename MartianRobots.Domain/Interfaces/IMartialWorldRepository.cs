using MartianRobots.Domain.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Domain.Interfaces
{
    /// <summary>
    /// Interface for the martian world operations
    /// </summary>
    public interface IMartianWorldRepository : IGenericRepository<MartianWorldEntity>
    {
        /// <summary>
        /// Get the last 10 execution results
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MartianWorldEntity>> GetLastTenMartianWorlds();
    }
}
