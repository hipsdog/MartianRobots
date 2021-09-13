using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialRobots.Models
{
    /// <summary>
    /// Object used to send executions input and result.
    /// </summary>
    public class MartialModel
    {
        /// <summary>
        /// Getter and setter of the input
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Martial world")]
        public string WorldInput { get; set; }

        /// <summary>
        /// Getter and setter of the input
        /// </summary>
        public List<string> WorldResult { get; set; }
    }
}
