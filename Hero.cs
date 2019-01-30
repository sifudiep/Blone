using System;
using System.Data;
using System.Xml;

namespace Blone
{
    public class Hero
    {
        private int _x;
        private int _y;
        public string _lookDirection;
        public int[,] VisionCoordinates = new int[25,2];

        public Hero()
        {
            _x = Console.WindowWidth/2;
            _y = Console.WindowHeight/2;
            DrawHero(_x, _y);
        }
        public void Spawn(int x, int y)
        {
            _x = x;
            _y = y;
            DrawHero(_x,_y);
        }

        public void UpdateVision()
        {
            var VisionCoordinateTracker = 0;
            // LOGIC FOR VISION DOWN
            for (int i = 1; i < 5; i++)
            {
                for (int j = _x; j < ((_x+1)+(2*i)); j++)
                {
                    Console.SetCursorPosition(j-i, i+_y);
                    Console.Write('*');
                    VisionCoordinates[VisionCoordinateTracker, 0] = j - i;
                    VisionCoordinates[VisionCoordinateTracker, 1] = i+_y;
                    VisionCoordinateTracker++;
                }
            }
        }

        public void EraseVision()
        {
            for (int i = 0; i < VisionCoordinates.Length/2; i++)
            {
                Console.SetCursorPosition(VisionCoordinates[i, 0], VisionCoordinates[i, 1]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            
        }

        public void EraseHero()
        {
            Console.SetCursorPosition(_x,_y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        public void DrawHero(int x, int y)
        {
            _y = y;
            _x = x;
            Console.SetCursorPosition(x, y);
            Console.Write('H');
        }

        public void LookDirection(string direction)
        {
            switch (direction) 
            {
                case DevHelper.DIRECTION_UP:
                    if (_lookDirection == DevHelper.DIRECTION_UP)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        _lookDirection = DevHelper.DIRECTION_UP;                        
                    }
                    break;
                case DevHelper.DIRECTION_DOWN:
                    if (_lookDirection == DevHelper.DIRECTION_DOWN)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        _lookDirection = DevHelper.DIRECTION_DOWN;
                    }
                    break;
                case DevHelper.DIRECTION_LEFT:
                    if (_lookDirection == DevHelper.DIRECTION_LEFT)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        _lookDirection = DevHelper.DIRECTION_LEFT;                        
                    }
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    if (_lookDirection == DevHelper.DIRECTION_RIGHT)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        _lookDirection = DevHelper.DIRECTION_RIGHT;                        
                    }
                    break;
            }
        }
        
        public void MoveHero(string direction)
        {
            switch (direction)
            {
                case DevHelper.DIRECTION_UP:
                    EraseHero();
                    DrawHero(_x, _y-1);
                    break;
                case DevHelper.DIRECTION_DOWN:
                    EraseHero();
                    DrawHero(_x, _y+1);
                    break;
                case DevHelper.DIRECTION_LEFT:
                    EraseHero();
                    DrawHero(_x-1, _y);
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    EraseHero();
                    DrawHero(_x+1, _y);
                    break;
            }
        }
    }
}