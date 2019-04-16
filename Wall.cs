using System;

namespace Blone
{
    public class Wall
    {
        /// <summary>
        /// Sets X and Y coordinate as x and y parameters.
        /// </summary>
        /// <param name="x">X coordinate to be used as the objects coordinate.-</param>
        /// <param name="y">Y coordinate to be used as the objects coordinate..</param>
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        /// <summary>
        /// Draws the wall at it's x and y coordinates. 
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X,Y);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write('#');
        }
    }
}