using System;

namespace Blone
{
    public class GameContainer
    {
        public GameContainer(Hero hero)
        {
            _hero = hero;
        }
        private ConsoleKeyInfo _keyInfo;
        private Hero _hero;
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                if ((_keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (_keyInfo.Key) 
                    {
                        case ConsoleKey.UpArrow:
                            _hero.LookDirection(DevHelper.DIRECTION_UP);
                            Console.WriteLine(_hero._lookDirection);
                            break;
                        case ConsoleKey.DownArrow:
                            _hero.LookDirection(DevHelper.DIRECTION_DOWN);
                            Console.WriteLine(_hero._lookDirection);
                            break;
                        case ConsoleKey.LeftArrow:
                            _hero.LookDirection(DevHelper.DIRECTION_LEFT);
                            Console.WriteLine(_hero._lookDirection);
                            break;
                        case ConsoleKey.RightArrow:
                            _hero.LookDirection(DevHelper.DIRECTION_RIGHT);
                            Console.WriteLine(_hero._lookDirection);
                            break;
                        case ConsoleKey.W:
                            _hero.MoveHero(DevHelper.DIRECTION_UP);
                            _hero.EraseVision();
                            _hero.UpdateVision();
                            break;
                        case ConsoleKey.S:
                            _hero.MoveHero(DevHelper.DIRECTION_DOWN);
                            _hero.EraseVision();
                            _hero.UpdateVision();
                            break;
                        case ConsoleKey.A:
                            _hero.MoveHero(DevHelper.DIRECTION_LEFT);
                            _hero.EraseVision();
                            _hero.UpdateVision();
                            break;
                        case ConsoleKey.D:
                            _hero.MoveHero(DevHelper.DIRECTION_RIGHT);
                            _hero.EraseVision();
                            _hero.UpdateVision();
                            break;
                        case ConsoleKey.Spacebar:
                            Console.WriteLine("SPACEBAR");
                            // Use powerup
                            break;
                    }
                }
            }
        }
    }
}