using System;

namespace MarsRover.Types
{
    /// <summary>
    ///  Represents a point on a 2-dimensional grid.
    /// </summary>
    public class Point
    {
        /// <summary>
        ///  The <c>x</c> and <c>y</c> coordinates of the <c>Point</c>
        /// </summary>
        public int x, y;

        /// <summary>
        ///  Instantiates a new <c>Point</c> with the given x and y coordinates
        /// </summary>
        /// <param name="x">The x (horizantal) coordinate of the <c>Point</c></param>
        /// <param name="y">The y (vertical) coordinate of the <c>Point</c></param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///  Default constructor. Creates a <c>Point</c> instance at 0, 0
        /// </summary>
        public Point() : this(0, 0) { }

        /// <summary>
        ///  Gives the coordinate in text format.
        /// </summary>
        /// <returns>A string displaying the points coordinates in "x, y" format</returns>
        public override String ToString()
        {
            return $"{x}, {y}";
        }

        /// <summary>
        ///  Attempts to parse the given string into a valid <c>Point</c> object.
        /// </summary>
        /// <param name="str">The string to parse</param>
        /// <param name="p">An out paramter that will either contain the successfully parsed
        /// <c>Point</c> or a <c>Point</c> at coordinates 0, 0 if unsuccessful.
        /// </param>
        /// <returns><c>true</c> if the string was successfully parsed, <c>false</c> otherwise.</returns>
        public static bool TryParse(String str, out Point p)
        {
            p = new Point();
            String[] tokens = str.Split();
            if (tokens.Length < 2)
            {
                return false;
            }
            int x, y;
            if (!(Int32.TryParse(tokens[0], out x) && Int32.TryParse(tokens[1], out y)))
            {
                return false;
            }
            if (x < 0 || y < 0)
            {
                return false;
            }
            p = new Point(x, y);
            return true;

        }
    }
}
