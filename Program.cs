using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Blone
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var gc = new GameContainer(new Hero());
            Console.CursorVisible = false;
            while (true)
            {
                gc.HandleInput();
            }

//            // COORDINATE ALGORITHM
//            int VisionCoordinateTracker = 0;
//            for (int i = 1; i < 5; i++)
//            {
//                for (int j = 30; j < (31+2*i); j++)
//                {
//                    // i = y & j-i = x
//                    Console.SetCursorPosition(j-i, i);
//                    Console.Write('*');
//                    
//                }
//            }
            
           
        }
    }
}