namespace Blone
{
    public class Shotgun : Gun
    {
        /// <summary>
        /// Sets the Gun fields for the shotgun derivative class. 
        /// </summary>
        public Shotgun()
        {
            MagazineSize = 5;
            AmmunitionInMagazine = 5;
            RoundsPerKSeconds = 1000;
            ReloadMilliseconds = 3000;
            AmmoType = DevHelper.ShotgunShell;
            ShootTimer.Start();
            Type = DevHelper.Shotgun;
        }
    }
}