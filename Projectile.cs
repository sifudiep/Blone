using System;
using System.Diagnostics;

namespace Blone
{
    public abstract class Projectile
    {
        /// <summary>
        /// Sets up x and y coordinate, also sets what direction for the projectile to continue moving in. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
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

            CheckCollision();
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

        /// <summary>
        /// Checks collision for the projectile. 
        /// </summary>
        /// <returns>A string describing what type of object it collided with.</returns>
        public string CheckCollision()
        {   
            var possibleX = X;
            var possibleY = Y;
            switch (Direction)
            {
                case DevHelper.Up:
                    possibleY -= 1;
                    break;
                case DevHelper.Down:
                    possibleY += 1;
                    break;
                case DevHelper.Right:
                    possibleX += 1;
                    break;
                case DevHelper.Left:
                    possibleX -= 1;
                    break;
            }
            
            for (int i = 0; i < GameContainer.EnemyList.Count; i++)
            {
                if (GameContainer.EnemyList[i].X == X && GameContainer.EnemyList[i].Y == Y)
                {
                    Erase();
                    Remove();
                    GameContainer.EnemyList.RemoveAt(i);
                    return DevHelper.EnemyCollision;
                }
            }

            for (int i = 0; i < GameContainer.WallList.Length; i++)
            {
                if (GameContainer.WallList[i].X == possibleX && GameContainer.WallList[i].Y == possibleY)
                {
                    Erase();
                    Remove();
                    return DevHelper.WallCollision;
                }
            }
            
            return DevHelper.NoCollision;
        }
        
        /// <summary>
        /// Draws the object at it's current x and y coordinates. 
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            switch (Type)
            {
                case DevHelper.Bullet:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case DevHelper.RifleAmmo:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case DevHelper.ShotgunShell:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
            }
            Console.Write("o");
        }
        
        /// <summary>
        /// Moves the projectile in the current direction.
        /// </summary>
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
        /// <summary>
        /// Erases the object console.
        /// </summary>
        public void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        /// <summary>
        /// Removes the object from the projectile list in GameContainer. 
        /// </summary>
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