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
        public abstract void Move();
        public abstract void Draw();
        public abstract string CheckCollision();
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