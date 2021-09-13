
namespace MartialRobots.Engine.Models
{
    /// <summary>
    /// Represents the robot position in the martian world.
    /// </summary>
    public class RobotPosition
    {
        /// <summary>
        /// Getter and setter for the position of the robot in the horizontal axis
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Getter and setter for the position of the robot in the vertical axis
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Getter and setter for the orientation of the robot (N, S, E, W)
        /// </summary>
        public char Orientation { get; set; }

        /// <summary>
        /// Function to create a shallow copy of the robot position
        /// </summary>
        public RobotPosition Clone()
        {
            return ((RobotPosition)MemberwiseClone());
        }

        /// <summary>
        /// Override of "Equals" to permit the use of the "Contains"
        /// We achieve a comparison by value instead of reference
        /// </summary>
        public override bool Equals(object obj)
        {
            RobotPosition item = obj as RobotPosition;

            if (item == null)
            {
                return false;
            }

            return this.X.Equals(item.X) && this.Y.Equals(item.Y) && this.Orientation.Equals(item.Orientation);
        }

        /// <summary>
        /// Override of "GetHashCode"
        /// </summary>
        public override int GetHashCode()
        {
            return (this.X.ToString() + this.Y.ToString() + this.Orientation).GetHashCode();
        }
    }
}
