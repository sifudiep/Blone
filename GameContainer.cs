using System;

namespace Blone
{
    public class GameContainer
    {
        private ConsoleKeyInfo _keyInfo;
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                if ((_keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (_keyInfo.Key) 
                    {
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("UPARROW");
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("DOWJNARROW");
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("LEFTARROW");
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("RIGHTARROW");
                            break;
                        case ConsoleKey.Z:
                            Console.WriteLine("Z");
                            // Shoot with current gun
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("X");
                            // Swap Gun
                            break;
                        case ConsoleKey.Spacebar:
                            Console.WriteLine("SPACEBAR");
                            // Use powerup
                            break;
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}