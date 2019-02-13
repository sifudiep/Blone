using System;
using System.Diagnostics;

namespace Blone
{
    public class Bullet : Projectile
    {
        public Bullet(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 10;
            Speed = 500;
            Type = DevHelper.Bullet;
            Draw();
        }

        public override void Move()
        {
            switch (Direction)
            {
                case DevHelper.Up:
                    Erase();
                    Y = Y - 1;
                    Draw();
                    break;
                case DevHelper.Down:
                    Erase();
                    Y = Y + 1;
                    Draw();
                    break;
                case DevHelper.Right:
                    Erase();
                    X = X + 1;
                    Draw();
                    break;
                case DevHelper.Left:
                    Erase();
                    X = X - 1;
                    Draw();
                    break;
            }
        }

        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("#");
        }

        public override string CheckCollision()
        {
            if (X-1 < 0 || X+1 > Console.BufferWidth || Y-1 < 0 || Y+1 > Console.BufferHeight)
                return DevHelper.OutOfBounds;
            
            // Not added enemies to collide with yet.
            
            return DevHelper.NoCollision;
        }
    }
}