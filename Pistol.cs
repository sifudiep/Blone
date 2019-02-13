namespace Blone
{
    public class Pistol : Gun
    {
        public Pistol()
        {
            MagazineSize = 10;
            AmmunitionInMagazine = 10;
            RoundsPerSecond = 2;
        }
        public override void Shoot(int x, int y, string direction)
        {
            if (AmmunitionInMagazine > 0)
            {
                GameContainer.ProjectileList.Add(new Bullet(x, y, direction));
                
            }
        }

        public override void Reload()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowGunUI()
        {
            throw new System.NotImplementedException();
        }
    }
}