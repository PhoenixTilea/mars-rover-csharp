using System;
using System.Collections.Generic;
using MarsRover.Types;
using MarsRover.Objects;

namespace MarsRover
{
    /// <summary>
    ///  A console application to simulate the control of a Mars rover on a 2-dimentional rectangular grid.
    /// </summary>
    class Program
    {
        /// <summary>
        ///  The main loop of the program. It prints an intro message, calls the <c>Control</c> method in a loop
        ///  until the user chooses to quit the application, then prints an outro message.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Mars Rover Command is now online.");
            bool quit = false;
            while (!quit)
            {
                quit = Control();
            }
            Console.WriteLine("Mars Rover Command is now offline.");
        }

        /// <summary>
        ///  This method runs the application flow. It collects the boundaries of the plateau, rover start position, 
        ///  and list of commands from the user, then outputs the rover's final position to the console. The user is prompted
        ///  each time to control a new rover, and if the negative option is chosen, the user is asked whather to define 
        ///  the boundaries of a new plateau. Choosing the negative option here will exit
        ///  the method and - subsequently - the program.
        /// </summary>
        /// <returns>Returns <c>true</c> if the user chooses to quit the app, <c>false</c> otherwise.</returns>
        public static bool Control()
        {
            Controller controller = new Controller(CommandReader.GetBounds());
            bool quit = false;
            while (!quit)
            {
                controller.AssignRover(new Rover(CommandReader.GetRoverStart(controller.Bounds)));
                List<Command> commands = CommandReader.GetCommands();
                foreach (Command c in commands)
                {
                    controller.SendCommand(c);
                }
                Console.WriteLine($"The rover is at {controller.GetRoverPosition()}");
                Console.WriteLine("Would you like to control a new rover?");
                quit = CommandReader.YesNo() == 'n';
            }
            Console.WriteLine("Would you like to move to a new plateau? [y/n]: ");
            return CommandReader.YesNo() == 'n';
        }
    }
}
