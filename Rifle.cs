namespace Blone
{
    public class Rifle : Gun
    {
        public Rifle()
        {
            MagazineSize = 30;
            AmmunitionInMagazine = 30;
            RoundsPerKSeconds = 100;
            ReloadMilliseconds = 5000;
            AmmoType = DevHelper.Brra;
            ShootTimer.Start();
        }
        public override void UpdateGunUI()
        {
            throw new System.NotImplementedException();
        }
    }
}