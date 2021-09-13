using MartialRobots.Engine.ConstantsHelper;
using MartialRobots.Engine.Models;
using System.IO;

namespace MartialRobots.Engine.Parser
{
    /// <summary>
    /// Static class that parses the input string and creates the martial world object
    /// </summary>
    public static class MartialWorldParser
    {
        /// <summary>
        /// Parses the raw string input of the world and returns the <see cref="MartialWorld"/> class.
        /// </summary>
        /// <param name="input">Raw string input of the martian world</param>
        /// <returns>The MartialWorld object.</returns>
        public static MartialWorld Parse(string input)
        {
            MartialWorld martialWorld = new();

            using (StringReader reader = new(input))
            {
                string line;
                int count = 0;

                RobotPosition robotPosition = null;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Length > 100)
                        {
                            martialWorld.ParsingErrors.Add($"{ErrorHelper.LENGTH_LIMIT_ERROR} : {line}");
                            break;
                        }
                        if (count == 0)
                        {
                            martialWorld.WorldSize = GetWorldSizeFromLine(line);
                            if (martialWorld.WorldSize == null)
                            {
                                martialWorld.ParsingErrors.Add($"{ErrorHelper.COORDINATES_ERROR} : {line}");
                                break;
                            }
                        }
                        else
                        {
                            if (IsOdd(count))
                            {
                                robotPosition = GetRobotLocation(line);
                                if (robotPosition == null)
                                {
                                    martialWorld.ParsingErrors.Add($"{ErrorHelper.ROBOT_POSITION_ERROR} : {line}");
                                    break;
                                }
                            }
                            else
                            {
                                RobotInstruction ronotInstruction = GetRobotInstructions(line);
                                if (ronotInstruction != null)
                                {
                                    martialWorld.Robots.Add(new Robot(robotPosition, ronotInstruction));
                                }
                                else
                                {
                                    martialWorld.ParsingErrors.Add($"{ErrorHelper.ROBOT_INSTRUCTION_ERROR} : {line}");
                                    break;
                                }
                            }
                        }
                        count++;
                    }
                }
            }

            return martialWorld;
        }


        private static WorldSize GetWorldSizeFromLine(string line)
        {
            WorldSize worldSize = new();

            string[] tokens = line.Split(' ');

            if (tokens.Length != 2 || !int.TryParse(tokens[0], out int x) || !int.TryParse(tokens[1], out int y)
                || x > 50 || y > 50)
            {
                return null;
            }

            worldSize.X = x;
            worldSize.Y = y;

            return worldSize;
        }

        private static RobotPosition GetRobotLocation(string line)
        {
            RobotPosition robotPosition = new();

            string[] tokens = line.Split(' ');

            if (tokens.Length != 3 || !int.TryParse(tokens[0], out int x) || !int.TryParse(tokens[1], out int y)
               || x > 50 || y > 50 || tokens[2].Length != 1 || !char.TryParse(tokens[2], out char orientation)
               || !OrientationHelper.ALL.Contains((tokens[2]).ToUpper()))
            {
                return null;
            }

            robotPosition.X = x;
            robotPosition.Y = y;
            robotPosition.Orientation = orientation;

            return robotPosition;
        }

        private static RobotInstruction GetRobotInstructions(string line)
        {
            RobotInstruction robotInstruction = new();

            foreach (char c in line)
            {
                if (!InstructionHelper.ALL.Contains(c))
                {
                    return null;
                }

                robotInstruction.Instructions.Add(c);
            }

            return robotInstruction;
        }

        private static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
