using System;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public class Enemy
    {
        public int X;
        public int Y;
        public int Index;
        private Hero _target; 

        public Enemy(int x, int y, Hero hero)
        {
            X = x;
            Y = y;
            _target = hero;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("E");
        }

        public void Remove()
        {
            GameContainer.EnemyList.RemoveAt(Index);
            Spawner.EnemyCounter--;
        }

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

        public void Move(string direction)
        {
            switch (direction)
            {
                case DevHelper.Up:
                    Y--;
                    break;
                case DevHelper.Down:
                    Y++;
                    break;
                case DevHelper.Left:
                    X--;
                    break;
                case DevHelper.Right:
                    X++;
                    break;
            }
        }
    }
}
