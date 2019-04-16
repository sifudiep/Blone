using System;

namespace Blone
{
    public class UserInterface
    {
        public readonly Hero CurrentPlayer;

        /// <summary>
        /// Reads the health and ammo from the current player. 
        /// </summary>
        /// <param name="currentPlayer">Same player object as in the game container, used for updating the health and ammo.</param>
        public UserInterface(Hero currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }

        
        
        /// <summary>
        /// Updates the health text in the user interface. 
        /// </summary>
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

        
        /// <summary>
        /// Updates the ammo text in the user interface.
        /// </summary>
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