using System;

namespace Blone
{
    public class UserInterface
    {
        public readonly Hero CurrentPlayer;

        public UserInterface(Hero currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }

        public void UpdateHealth()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DevHelper.XHealth, DevHelper.YHealth);

            if (CurrentPlayer.Health >= 100)
            {
                Console.Write("Health : " + CurrentPlayer.Health);                
            }
            else
            {
                Console.Write("Health :  " + CurrentPlayer.Health);
            }
        }

        public void UpdateAmmo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DevHelper.XAmmo, DevHelper.YAmmo);
            if (CurrentPlayer.Gun.AmmunitionInMagazine < 10)
            {
                Console.Write(CurrentPlayer.Gun.Type + " - 0" + CurrentPlayer.Gun.AmmunitionInMagazine + "/" + CurrentPlayer.Gun.MagazineSize);
            }
            else
            {
                Console.Write(CurrentPlayer.Gun.Type + " - " + CurrentPlayer.Gun.AmmunitionInMagazine + "/" + CurrentPlayer.Gun.MagazineSize);

            }
        }
    }
}