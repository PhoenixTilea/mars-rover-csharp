using System;
using MarsRover.Types;

namespace MarsRover.Objects
{
    /// <summary>
    ///  Represents a Mars Rover which can be externally controlled.
    /// </summary>
    public class Rover
    {
        PointWithHead position;

        /// <summary>
        ///  Get the current position (coordinates and facing direction) of the <c>Rover</c> object.
        /// </summary>
        public PointWithHead Position { get { return this.position; } }

        /// <summary>
        ///  Creates a new <c>Rover</c> instance at the given position
        /// </summary>
        /// <param name="position">The starting coordinates and facing direction of the <c>Rover</c></param>
        public Rover(PointWithHead position)
        {
            this.position = position;
        }

        /// <summary>
        ///  Moves the <c>Rover</c> 1 grid space forward according to the direction in which it is facing
        /// </summary>
        public void Move()
        {
            switch (this.position.head)
            {
                case Direction.N:
                    this.position.y++;
                    break;
                case Direction.E:
                    this.position.x++;
                    break;
                case Direction.S:
                    this.position.y--;
                    break;
                case Direction.W:
                    this.position.x--;
                    break;
            }
        }

        /// <summary>
        ///  Turns the rover 90 degrees left
        /// </summary>
        public void TurnLeft()
        {
            this.Turn(-1);
        }

        /// <summary>
        ///  Turns the rover 90 degrees right
        /// </summary>
        public void TurnRight()
        {
            this.Turn(1);
        }

        /// <summary>
        ///  An internal method for turning the <c>Rover</c> based on a numeric value
        /// </summary>
        /// <param name="dir"><c>-1</c> turns the rover left, <c>1</c>c> turns the <c>Rover</c>right</param>
        private void Turn(int dir)
        {
            int facing = (int)this.position.head + dir;
            if (facing < 0)
            {
                facing = 3;
            }
            else if (facing > 3)
            {
                facing = 0;
            }
            this.position.head = (Direction)facing;
        }
    }
}
