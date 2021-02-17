using System;
using MarsRover.Types;

namespace MarsRover.Objects
{
    /// <summary>
    ///  Represents a control mechanism used to send remote commands to a <c>Rover</c>
    /// </summary>
    public class Controller
    {
        Point bounds;
        /// <summary>
        ///  The northeastern boundary of the plateau on which this <c>Controller's</c> assigned <c>Rover</c> is operating.
        ///  The <c>Controller</c> is responsible for ensuring it does not send its <c>Rover</c> out of bounds.
        /// </summary>
        public Point Bounds { get { return bounds; } }

        Rover rover;

        /// <summary>
        ///  Instantiates a new <c>Controller</c>
        /// </summary>
        /// <param name="bounds">The northeastern boundary oof the plateau this <c>Controller</c> will operate on</param>
        public Controller(Point bounds)
        {
            this.bounds = bounds;
        }

        /// <summary>
        ///  Assigns a new <c>Rover</c> to this <c>Controller</c>
        /// </summary>
        /// <param name="rover">The new <c>Rover</c> to control</param>
        public void AssignRover(Rover rover)
        {
            this.rover = rover;
        }

        /// <summary>
        ///  Gets the current position of its assigned <c>Rover</c>
        /// </summary>
        /// <returns>The current position and facing direction of the previously assigned <c>Rover</c></returns>
        public PointWithHead GetRoverPosition()
        {
            return rover.Position;
        }

        /// <summary>
        ///  Interprets the provided command and sends it on to the assigned <c>Rover</c>
        /// </summary>
        /// <param name="c">The <c>Command</c>c> to issue</c></param>
        public void SendCommand(Command c)
        {
            switch (c)
            {
                case Command.Left:
                    rover.TurnLeft();
                    break;
                case Command.Right:
                    rover.TurnRight();
                    break;
                case Command.Move:
                    if (CanMoveRover())
                    {
                        rover.Move();
                    }
                    break;
            }
        }

        /// <summary>
        ///  Determines whether the assigned rover can be moved in the direction it is facing, or whether it has hit a boundary.
        /// </summary>
        /// <returns><c>true</c> if the <c>Rover</c> can safely move, <c>false</c> otherwise.</returns>
        private bool CanMoveRover()
        {
            PointWithHead pos = GetRoverPosition();
            if (pos.head == Direction.N && pos.y == bounds.y)
            {
                return false;
            }
            else if (pos.head == Direction.E && pos.x == bounds.x)
            {
                return false;
            }
            else if (pos.head == Direction.S && pos.y == 0)
            {
                return false;
            }
            else if (pos.head == Direction.W && pos.x == 0)
            {
                return false;
            }
            return true;
        }
    }
}
