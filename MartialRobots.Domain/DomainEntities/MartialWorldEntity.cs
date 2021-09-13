using System;
using System.ComponentModel.DataAnnotations;

namespace MartialRobots.Domain.DomainEntities
{
    /// <summary>
    /// Martial world entity 
    /// </summary>
    public class MartialWorldEntity
    {
        /// <summary>
        /// AuotGenerated sql Id
        /// </summary>
        [Key]
        public int MartialWorldId { get; set; }

        /// <summary>
        /// Martial world Input
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Martial world Output
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Martial world Execution Date
        /// </summary>
        public DateTime ExecutionDate { get; set; }
    }
}
