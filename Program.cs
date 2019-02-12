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
        }
    }
}