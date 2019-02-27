using System;
using System.Diagnostics;

namespace Blone
{
    public abstract class Projectile
    {
        public Projectile(int x, int y, string direction)
        {
            Direction = direction;
            switch (direction)
            {
                case DevHelper.Up:
                    X = x;
                    Y = y - 1;
                    break;
                case DevHelper.Down:
                    X = x;
                    Y = y + 1;
                    break;
                case DevHelper.Left:
                    X = x - 1;
                    Y = y;
                    break;
                case DevHelper.Right:
                    X = x + 1;
                    Y = y;
                    break;
            }
        }

        public int X;
        public int Y;
        public Stopwatch MoveStopwatch = new Stopwatch();
        public int Damage;
        public int Speed;
        public int MaxDistance;
        public bool Removed;
        public string Type; 
        public string Direction;
        public ConsoleColor FormerBackgroundColor;
        public int DistanceTraveled = 0;

        public string CheckCollision()
        {
            if (X-1 < 0 || X+1 > Console.BufferWidth || Y-1 < 0 || Y+1 > Console.BufferHeight)
                return DevHelper.OutOfBounds;
            
            // Not added enemies to collide with yet.
            
            return DevHelper.NoCollision;
        }
        
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            switch (Type)
            {
                case DevHelper.Bullet:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case DevHelper.Brra:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case DevHelper.Bom:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
            }
            Console.Write("o");
        }
        
        public void Move()
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
                MoveStopwatch.Restart();
            }
            else if (Removed == false)
            {
                Erase();
                Remove();
            }
        }
        public void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        public void Remove()
        {
            for (int i = 0; i < GameContainer.ProjectileList.Count; i++)
            {
                if (GameContainer.ProjectileList[i].X == X
                    && GameContainer.ProjectileList[i].Y == Y
                    && GameContainer.ProjectileList[i].Type == Type)
                {
                    Removed = true;
                    GameContainer.ProjectileList.RemoveAt(i);
                }
            }
            
        }
    }
}