using System;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public class Enemy
    {
        public int X;
        public int Y;
        private Hero _target; 

        /// <summary>
        /// Sets x,y coordinate for the player, also sets it's target as the current Hero.
        /// </summary>
        /// <param name="x">Sets the x param to its x coordinate.</param>
        /// <param name="y">Sets the y param to its y coordinate.</param>
        /// <param name="hero">Sets the hero param to its _target.</param>
        public Enemy(int x, int y, Hero hero)
        {
            X = x;
            Y = y;
            _target = hero;
        }

        /// <summary>
        /// Draws the enemy object. 
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("E");
        }

        /// <summary>
        /// Erases enemy from console.
        /// </summary>
        public void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        /// <summary>
        /// Removes the enemy object from the EnemyList in GameContainer.
        /// </summary>
        public void Remove()
        {
            for (int i = 0; i < GameContainer.EnemyList.Count; i++)
            {
                if (GameContainer.EnemyList[i].X == X && GameContainer.EnemyList[i].Y == Y)
                {
                    GameContainer.EnemyList.RemoveAt(i);
                    break;
                }
            }
        }
        

        /// <summary>
        /// Algorithm for the enemies to hunt the _target. 
        /// </summary>
        public void HuntHero()
        {
            // Calculate Y & X distance between enemy and player.
            var yDistance = 0;
            var xDistance = 0;
            string yDirection;
            string xDirection;
            
            Console.SetCursorPosition(100, 20);
            Console.WriteLine("HERO-Y: " + _target.Y);
            Console.SetCursorPosition(100, 22);
            Console.WriteLine("HERO-X: " + _target.X);

            if (_target.Y >= Y)
            {
                yDistance = _target.Y - Y;
                yDirection = DevHelper.Down;
            }
            else
            {
                yDistance = Y - _target.Y;
                yDirection = DevHelper.Up;
            }

            if (_target.X >= X)
            {
                xDistance = _target.X - X;
                xDirection = DevHelper.Right;
            }
            else
            {
                xDistance = X - _target.X;
                xDirection = DevHelper.Left;
            }
            
//            Console.SetCursorPosition(100, 24);
//            Console.WriteLine("XDistance: " + xDistance);
//            Console.SetCursorPosition(100, 25);
//            Console.WriteLine("YDistance: " + yDistance);
//            Console.SetCursorPosition(100, 26);
//            Console.WriteLine("XDirection: " + xDirection);
//            Console.SetCursorPosition(100, 27);
//            Console.WriteLine("YDirection: " + yDirection);

            if (xDistance == 0 && yDistance == 0)
            {
                _target.Health -= DevHelper.EnemyDamage;
                GameContainer.UserInterface.UpdateHealth();
                
                Remove();                
            }
                

            if (yDistance > xDistance)
            {
                Move(yDirection);
            }
            else
            {
                Move(xDirection);
            }
            
            
        }

        /// <summary>
        /// Move function for the enemy object. 
        /// </summary>
        /// <param name="direction">Direction for the objects move.</param>
        public void Move(string direction)
        {
            var possibleX = X;
            var possibleY = Y;
            
            switch (direction)
            {
                case DevHelper.Up:
                    possibleY--;
                    break;
                case DevHelper.Down:
                    possibleY++;
                    break;
                case DevHelper.Left:
                    possibleX--;
                    break;
                case DevHelper.Right:
                    possibleX++;
                    break;
            }
            
            for (int i = 0; i < Hero.VisionCoordinates.Count; i++)
            {
                if (Hero.VisionCoordinates[i].X == possibleX && Hero.VisionCoordinates[i].Y == possibleY
                    )
                {
                    Erase();
                    X = possibleX;
                    Y = possibleY;
                    Draw();
                    break;
                }
            }
            
            X = possibleX;
            Y = possibleY;
        }
    }
}
