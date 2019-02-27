using System;

namespace Blone
{
    public class Enemy
    {
        private int _x;
        private int _y;
        public int StepsPerKSeconds;
        public int Health;
        public int Damage;

        public Enemy(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("E");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}