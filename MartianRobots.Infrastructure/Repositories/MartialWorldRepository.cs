using MartianRobots.Domain.DomainEntities;
using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.Infrastructure.Repositories
{
    /// <summary>
    /// Martian world repository.
    /// Holds the busines logic
    /// </summary>
    public class MartianWorldRepository : GenericRepository<MartianWorldEntity>, IMartianWorldRepository
    {
        /// <summary>
        /// Respository constructor
        /// </summary>
        /// <param name="context"></param>
        public MartianWorldRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc cref="IMartianWorldRepository" />
        public async Task<IEnumerable<MartianWorldEntity>> GetLastTenMartianWorlds()
        {
            return await _context.MartianWorlds.OrderByDescending(p => p.ExecutionDate).Take(10).ToListAsync();
        }
    }
}
