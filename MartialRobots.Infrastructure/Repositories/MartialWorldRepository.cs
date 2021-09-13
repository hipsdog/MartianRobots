using MartialRobots.Domain.DomainEntities;
using MartialRobots.Domain.Interfaces;
using MartialRobots.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialRobots.Infrastructure.Repositories
{
    /// <summary>
    /// Martial world repository.
    /// Holds the busines logic
    /// </summary>
    public class MartialWorldRepository : GenericRepository<MartialWorldEntity>, IMartialWorldRepository
    {
        /// <summary>
        /// Respository constructor
        /// </summary>
        /// <param name="context"></param>
        public MartialWorldRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc cref="IMartialWorldRepository" />
        public async Task<IEnumerable<MartialWorldEntity>> GetLastTenMartialWorlds()
        {
            return await _context.MartialWorlds.OrderByDescending(p => p.ExecutionDate).Take(10).ToListAsync();
        }
    }
}
