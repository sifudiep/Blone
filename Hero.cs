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
            DrawHero(X,Y);
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
        
        public void MoveHero(string direction)
        {
            switch (direction)
            {
                case "up":
                    EraseHero();
                    Y -= 1;
                    DrawHero(X, Y);
                    break;
                case "down":
                    EraseHero();
                    Y += 1;
                    DrawHero(X, Y);
                    break;
                case "left":
                    EraseHero();
                    X -= 1;
                    DrawHero(X, Y);
                    break;
                case "right":
                    EraseHero();
                    X += 1;
                    DrawHero(X, Y);
                    break;
            }
        }
    }
}