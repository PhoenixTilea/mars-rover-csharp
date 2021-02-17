using System;
using System.Collections.Generic;
using MarsRover.Types;

namespace MarsRover
{
    /// <summary>
    ///  <summary>
    ///  <c>CommandReader</c> contains several static methods to prompt the user
    ///  for input, collect and parse that input, and return
    ///  data usable by the calling method.
    /// </summary>
    /// </summary>
    public class CommandReader
    {
        /// <summary>
        ///  <summary>
        ///  Accepts input from the user in response to an external 'yes' or 'no' question.
        /// </summary>
        /// <returns><c>'y'</c>c> if the user's input began with the letter 'y', <c>'n'</c>c> otherwise.</returns>
        public static char YesNo()
        {
            String response = Console.ReadLine().ToLower();
            if (response.Length > 0 && response[0] == 'y')
            {
                return 'y';
            }
            return 'n';
        }
        
        /// <summary>
        ///  Prompts the user for an x y coordinate representing the
        ///  northeastern boundary of a rectangular plateau.
        ///  </summary>
        /// <returns>The user's input represented as a <c>Point</c> object.</returns>
        public static Point GetBounds()
        {
            while (true) 
            { 
                Console.WriteLine("Provide the  coordinates of the plateau's northeastern boundary. [x y]: ");
                String bString = Console.ReadLine();
                if (Point.TryParse(bString, out Point bounds))
                {
                    return bounds;
                }
                Console.WriteLine("Invalid Entry: Please enter two positive integers separated by a space character (ex. \"5 5\")");
                        }
        }

        /// <summary>
        ///  Prompts the user for the starting position of the new rover and the 
        ///  direction in which it is facing.
        /// </summary>
        /// <param name="bounds">A <c>Point</c> representing the northeastern boundary of the plateau as entered previously by the user.</param>
        /// <returns>The user's input as a <c>PointWithHead</c> object.</returns>
        public static PointWithHead GetRoverStart(Point bounds)
        {
while (true)
            {
                Console.WriteLine("Enter the rover's starting coordinates and the direction it is facing. [x y N|E|S|W]: ");
                String str = Console.ReadLine();
                PointWithHead start;
                if (!PointWithHead.TryParse(str, out start))
                {
                    Console.WriteLine("Invalid Entry: Please enter two positive integers separated by a space character, followed by another space character and letter representing a cardinal direction (ex. \"0 0 N\")");
                    continue;
                } else if (start.x > bounds.x || start.y > bounds.y)
                {
                    Console.WriteLine($"Out of Bounds: The rover must begin within the bounds set by the plateau: {bounds}");
                    continue;
                }
                return start;
            }
        }

        /// <summary>
        ///  Prompts the user for a single string containing commands for the rover:
        ///  <list>
        ///  <item>
        /// <term>L</term>
        /// <description>Turn the rover left 90 degrees</description> 
        /// </item>
        /// <item>
        /// <term>R</term>
        /// <description>Turn the rover 90 degrees right</description>
        /// </item>
        /// <item>
        /// <term>M</term>
        /// <description>Move the rover 1 space forward in the direction it is facing</description>
        /// </item>
        ///  </list>
        /// </summary>
        /// <returns>The user's commands filtered and converted to a <c>List</c>c> of <c>Direction</c> enum values</returns>
        public static List<Command> GetCommands()
        {
while (true)
            {
                Console.WriteLine("Please enter a string of commands without spaces - 'L' to turn the rover left, 'R' to turn the rover right, and 'M' to move the rover one space forward. Invalid commands will be ignored. [MMRMMLM]: ");
                String str = Console.ReadLine();
if (String.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please enter a response.");
                    continue;
                }
                List<Command> commands = new List<Command>();
                foreach (char c in str.ToUpper())
                {
switch (c)
                    {
                        case 'L':
                            commands.Add(Command.Left);
                            break;
                        case 'R':
                            commands.Add(Command.Right);
                            break;
                        case 'M':
                            commands.Add(Command.Move);
                            break;
                        default: break;
                    }
                }
                return commands;
            }
        }

    }
}
