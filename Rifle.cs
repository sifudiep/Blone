namespace Blone
{
    public class Rifle : Gun
    {
        /// <summary>
        /// Sets the Gun fields for the rifle derivative class. 
        /// </summary>
        public Rifle()
        {
            MagazineSize = 30;
            AmmunitionInMagazine = 30;
            RoundsPerKSeconds = 100;
            ReloadMilliseconds = 5000;
            AmmoType = DevHelper.RifleAmmo;
            Type = DevHelper.Rifle;
            ShootTimer.Start();
        }
    }
}