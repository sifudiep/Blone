namespace Blone
{
    public class Shotgun : Gun
    {
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