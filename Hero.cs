using System;

namespace Blone
{
    public class Hero
    {
        private int X;
        private int Y;
        
        public void Spawn(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void EraseHero()
        {
            Console.SetCursorPosition(X,Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        public void DrawHero(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write('H');
        }
        
        public void MoveHero(int x, int y, string direction)
        {
            switch (direction)
            {
                case "up":
                    EraseHero();
                    DrawHero(x, (y - 1));
                    break;
                case "down":
                    EraseHero();
                    DrawHero(x, (y + 1));
                    break;
                case "left":
                    EraseHero();
                    DrawHero((x - 1), y);
                    break;
                case "right":
                    EraseHero();
                    DrawHero((x + 1), y);
                    break;
            }
        }
    }
}