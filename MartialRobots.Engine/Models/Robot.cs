
namespace MartialRobots.Engine.Models
{
    /// <summary>
    /// Represents a robot in the martian world
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Robot"/> class.
        /// </summary>
        public Robot()
        {
            RobotPosition = new();
            FinalPosition = new();
            RobotInstruction = new();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Robot"/> class.
        /// </summary>
        /// <param name="robotPosition">The robot position instance</param>
        /// <param name="robotInstruction">The robot instruction instance</param>
        public Robot(RobotPosition robotPosition, RobotInstruction robotInstruction)
        {
            RobotPosition = robotPosition;
            RobotInstruction = robotInstruction;
            FinalPosition = new();
        }

        /// <summary>
        /// Getter and setter of the robot position
        /// </summary>
        public RobotPosition RobotPosition { get; set; }

        /// <summary>
        /// Getter and setter of the final position
        /// </summary>
        public RobotPosition FinalPosition { get; set; }

        /// <summary>
        /// Getter and setter of the robot instruction
        /// </summary>
        public RobotInstruction RobotInstruction { get; set; }

        /// <summary>
        /// Getter and setter of the boolean indicating if the robot is lost or not
        /// </summary>
        public bool IsLost { get; set; } = false;
    }
}
