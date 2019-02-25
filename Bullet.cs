using System;
using System.Diagnostics;

namespace Blone
{

    public class Brra : Projectile
    {
        public Brra(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 7;
            Speed = 100;
            MaxDistance = 10;
            Type = DevHelper.Brra;
            Removed = false;
            Draw();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override string CheckCollision()
        {
            throw new NotImplementedException();
        }
    }
    public class Bullet : Projectile
    {
        public Bullet(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 10;
            Speed = 50;
            MaxDistance = 10;
            Type = DevHelper.Bullet;
            Removed = false;
            Draw();
        }

        public int DistanceTraveled = 0;

        public override void Move()
        {
            if (DistanceTraveled < MaxDistance)
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
                DistanceTraveled++;
                MoveStopwatch.Reset();
            }
            else if (Removed == false)
            {
                Erase();
                Remove();
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("o");
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