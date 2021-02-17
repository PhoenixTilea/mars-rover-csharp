using System;

namespace MarsRover.Types
{
    /// <summary>
    ///  Represents an x, y position on a 2 dimensional plane, including a direction in which
    ///  an object at this location is facing.
    /// </summary>
    public class PointWithHead : Point
    {
        /// <summary>
        ///  The cardinal direction in which an object located at this point is facing
        /// </summary>
        public Direction head;

        /// <summary>
        ///  Constructs a new PointWithHead given the x, y, and head information.
        /// </summary>
        /// <param name="x">The x (horizantal) coordinate of this <c>PointWithHead</c></param>
        /// <param name="y">The y (vertical) coordinate of this <c>PointWithHead</c></param>
        /// <param name="head">The heading <c>Direction</c> of this <c>PointWithHead</c>c></param>
        public PointWithHead(int x, int y, Direction head) : base(x, y)
        {
            this.head = head;
        }

        /// <summary>
        ///  Default constructor: Creates a new <c>PointWithHead</c> at position 0, 0 and facing north
        /// </summary>
        public PointWithHead() : this(0, 0, Direction.N) { }

        /// <summary>
        ///  Gives the text represenataion of this location.
        /// </summary>
        /// <returns>A string in the format "x, y, DIR"</returns>
        public override String ToString()
        { 
            return $"{base.ToString()}, {head}";
        }

        /// <summary>
        ///  Attempts to parse the given string into a <c>PointWithHead</c> object.
        /// </summary>
        /// <param name="str">The string to parse</param>
        /// <param name="p">An out parameter which will contain either the successfully parsed <c>PointWithHead</c> or a <c>PointWithHead</c> at 
        /// the default position of 0, 0, N if unsuccessful
        /// </param>
        /// <returns><c>true</c> if the string could be successfully parsed, <c>false</c> otherwise.</returns>
        public static bool TryParse(String str, out PointWithHead p)
        {
            p = new PointWithHead();
            Point point;
            if (!Point.TryParse(str, out point))
            {
                return false;
            }
            char dir = str.Trim().ToUpper()[str.Length - 1];
            Direction head;
            switch (dir)
            {
                case 'N':
                    head = Direction.N;
                    break;
                case 'E':
                    head = Direction.E;
                    break;
                case 'S':
                    head = Direction.S;
                    break;
                case 'W':
                    head = Direction.W;
                    break;
                default:
                    return false;
            }
            p = new PointWithHead(point.x, point.y, head);
            return true;
        }
    }
}
