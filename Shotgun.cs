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
            AmmoType = DevHelper.Bom;
            ShootTimer.Start();
        }
        public override void UpdateGunUI()
        {
            throw new System.NotImplementedException();
        }
    }
}