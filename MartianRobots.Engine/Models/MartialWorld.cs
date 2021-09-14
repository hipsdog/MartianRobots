using System.Collections.Generic;

namespace MartianRobots.Engine.Models
{
    /// <summary>
    /// Represents the martian world, contains the size of the planet, the robot with their instructions
    /// And a list of the last positions before the robots where lost.
    /// </summary>
    public class MartianWorld
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MartianWorld"/> class.
        /// </summary>
        public MartianWorld()
        {
            this.WorldSize = new();
            this.Robots = new();
            this.LastSeenPositions = new();
            this.ParsingErrors = new();
        }

        /// <summary>
        /// Getter and setter of the world size
        /// </summary>
        public WorldSize WorldSize { get; set; }

        /// <summary>
        /// Getter and setter of the list of robots
        /// </summary>
        public List<Robot> Robots { get; set; }

        /// <summary>
        /// Getter and setter of the last seen positions list
        /// </summary>
        public List<RobotPosition> LastSeenPositions { get; set; }

        /// <summary>
        /// Getter and setter of the parsing error list 
        /// </summary>
        public List<string> ParsingErrors { get; set; }
    }
}
