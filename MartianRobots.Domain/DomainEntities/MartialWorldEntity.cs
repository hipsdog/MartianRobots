using System;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Domain.DomainEntities
{
    /// <summary>
    /// Martian world entity 
    /// </summary>
    public class MartianWorldEntity
    {
        /// <summary>
        /// AuotGenerated sql Id
        /// </summary>
        [Key]
        public int MartianWorldId { get; set; }

        /// <summary>
        /// Martian world Input
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Martian world Output
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Martian world Execution Date
        /// </summary>
        public DateTime ExecutionDate { get; set; }
    }
}
