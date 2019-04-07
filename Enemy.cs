using System;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public class Enemy
    {
        public int X;
        public int Y;
        public int StepsPerKSeconds;

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("E");
        }
    }
}