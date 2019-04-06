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
            Console.Write("Health : " + CurrentPlayer.Health);
        }

        public void UpdateAmmo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DevHelper.XAmmo, DevHelper.YAmmo);
            Console.Write(CurrentPlayer.Gun.Type + " - " + CurrentPlayer.Gun.AmmunitionInMagazine + "/" + CurrentPlayer.Gun.MagazineSize);
        }
    }
}