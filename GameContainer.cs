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
                            _hero.ChangeLookDirection(DevHelper.DIRECTION_UP);
                            break;
                        case ConsoleKey.DownArrow:
                            _hero.ChangeLookDirection(DevHelper.DIRECTION_DOWN);
                            break;
                        case ConsoleKey.LeftArrow:
                            _hero.ChangeLookDirection(DevHelper.DIRECTION_LEFT);
                            break;
                        case ConsoleKey.RightArrow:
                            _hero.ChangeLookDirection(DevHelper.DIRECTION_RIGHT);
                            break;
                        case ConsoleKey.W:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.DIRECTION_UP);
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.S:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.DIRECTION_DOWN);
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.A:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.DIRECTION_LEFT);
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.D:                            
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.DIRECTION_RIGHT);
                            _hero.UpdateVision(_hero.LookDirection);
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