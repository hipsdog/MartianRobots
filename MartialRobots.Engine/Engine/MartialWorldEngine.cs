using MartialRobots.Engine.ConstantsHelper;
using MartialRobots.Engine.Models;
using System.Collections.Generic;

namespace MartialRobots.Engine.Engine
{
    /// <summary>
    /// Contains the functionalities to transform the received martial world to the final state.
    /// </summary>
    public static class MartialWorldEngine
    {
        /// <summary>
        /// Execute the instructions for all the robot of the given martial world
        /// </summary>
        /// <param name="martialWorld">MartialWorld object</param>
        /// <returns>List of all robots last positions</returns>
        public static List<string> Execute(MartialWorld martialWorld)
        {
            foreach (Robot robot in martialWorld.Robots)
            {
                foreach (var instruction in robot.RobotInstruction.Instructions)
                {

                    robot.FinalPosition = robot.RobotPosition.Clone();

                    if (IsRobotLostBreak(martialWorld, robot)) break;


                    if (!martialWorld.LastSeenPositions.Contains(robot.RobotPosition) || instruction != InstructionHelper.FORWARD)
                    {
                        UpdateRobotPosition(robot, instruction);
                    }

                    if (IsRobotLostBreak(martialWorld, robot)) break;
                }
            }

            return GetResultString(martialWorld);
        }

        private static List<string> GetResultString(MartialWorld martialWorld)
        {
            List<string> result = new();

            foreach (var robot in martialWorld.Robots)
            {
                result.Add(robot.RobotPosition.X.ToString() + " " 
                    + robot.RobotPosition.Y.ToString() + " "
                    + robot.RobotPosition.Orientation.ToString()
                    + (robot.IsLost ? " LOST" : ""));
            }

            return result;
        }

        private static bool IsRobotLostBreak(MartialWorld martialWorld, Robot robot)
        {
            if (robot.IsLost || IsRobotLost(robot, martialWorld.WorldSize))
            {
                martialWorld.LastSeenPositions.Add(robot.FinalPosition);
                robot.RobotPosition = robot.FinalPosition;
                robot.IsLost = true;
                return true;
            }
            return false;
        }

        private static void UpdateRobotPosition(Robot robot, char intsruction)
        {
            switch (intsruction)
            {
                case InstructionHelper.FORWARD:
                    ForwordRobot(robot);
                    break;
                case InstructionHelper.RIGHT:
                    TurnRobotRight(robot);
                    break;
                case InstructionHelper.LEFT:
                    TurnRobotLeft(robot);
                    break;
            }
        }

        private static void TurnRobotRight(Robot robot)
        {
            switch (robot.RobotPosition.Orientation)
            {
                case OrientationHelper.NORTH:
                    robot.RobotPosition.Orientation = OrientationHelper.EAST;
                    break;
                case OrientationHelper.SOUTH:
                    robot.RobotPosition.Orientation = OrientationHelper.WEST;
                    break;
                case OrientationHelper.EAST:
                    robot.RobotPosition.Orientation = OrientationHelper.SOUTH;
                    break;
                case OrientationHelper.WEST:
                    robot.RobotPosition.Orientation = OrientationHelper.NORTH;
                    break;
            }
        }

        private static void TurnRobotLeft(Robot robot)
        {
            switch (robot.RobotPosition.Orientation)
            {
                case OrientationHelper.NORTH:
                    robot.RobotPosition.Orientation = OrientationHelper.WEST;
                    break;
                case OrientationHelper.SOUTH:
                    robot.RobotPosition.Orientation = OrientationHelper.EAST;
                    break;
                case OrientationHelper.EAST:
                    robot.RobotPosition.Orientation = OrientationHelper.NORTH;
                    break;
                case OrientationHelper.WEST:
                    robot.RobotPosition.Orientation = OrientationHelper.SOUTH;
                    break;
            }
        }

        private static void ForwordRobot(Robot robot)
        {
            switch (robot.RobotPosition.Orientation)
            {
                case OrientationHelper.NORTH:
                    robot.RobotPosition.Y++;
                    break;
                case OrientationHelper.SOUTH:
                    robot.RobotPosition.Y--;
                    break;
                case OrientationHelper.EAST:
                    robot.RobotPosition.X++;
                    break;
                case OrientationHelper.WEST:
                    robot.RobotPosition.X--;
                    break;
            }
        }

        private static bool IsRobotLost(Robot robot, WorldSize worldSize)
        {
            if (robot.RobotPosition.X > worldSize.X || robot.RobotPosition.Y > worldSize.Y)
            {
                return true;
            }

            return false;
        }
    }
}
