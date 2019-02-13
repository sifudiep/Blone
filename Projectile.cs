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
        public string Type; 
        public string Direction;
        public abstract void Move();
        public abstract void Erase();
        public abstract void Draw();
        public abstract string CheckCollision();
    }
}