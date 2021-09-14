using System;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Models
{
    /// <summary>
    /// Object used to list the execution information.
    /// </summary>
    public class MartianWorldHistory
    {
        /// <summary>
        /// Getter and setter for the world input
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "World input")]
        public string WorldInput { get; set; }

        /// <summary>
        /// Getter and setter for the world output
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "World output")]
        public string WorldResult { get; set; }

        /// <summary>
        /// Getter and setter for the execution date
        /// </summary>
        [Display(Name = "Execution date")]
        public DateTime ExecutionDate { get; set; }
    }
}
