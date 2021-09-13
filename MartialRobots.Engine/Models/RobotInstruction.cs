using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialRobots.Engine.Models
{
    /// <summary>
    /// Represents the list of the robot instructions
    /// </summary>
    public class RobotInstruction
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="RobotInstruction"/> class.
        /// </summary>
        public RobotInstruction()
        {
            this.Instructions = new();
        }

        /// <summary>
        /// Getter and setter for instructions list
        /// </summary>
        public List<char> Instructions { get; set; }
    }
}
