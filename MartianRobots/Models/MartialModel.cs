using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Models
{
    /// <summary>
    /// Object used to send executions input and result.
    /// </summary>
    public class MartianModel
    {
        /// <summary>
        /// Getter and setter of the input
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Martian world")]
        public string WorldInput { get; set; }

        /// <summary>
        /// Getter and setter of the input
        /// </summary>
        public List<string> WorldResult { get; set; }
    }
}
