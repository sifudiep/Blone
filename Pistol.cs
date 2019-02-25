using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blone
{
    public class Pistol : Gun
    {
        Stopwatch ShootTimer = new Stopwatch();
        Stopwatch ReloadTimer = new Stopwatch();
        
        public Pistol()
        {
            MagazineSize = 10;
            AmmunitionInMagazine = 10;
            RoundsPerKSeconds = 500;
            ReloadMilliseconds = 3000;
            ShootTimer.Start();
        }
        public override void Shoot(int x, int y, string direction)
        {
            if (AmmunitionInMagazine > 0 && ShootTimer.ElapsedMilliseconds > RoundsPerKSeconds)
            {
                GameContainer.ProjectileList.Add(new Bullet(x, y, direction));
                ShootTimer.Restart();
                AmmunitionInMagazine--;
            }
        }

        public override async void Reload()
        {
           ReloadTimer.Start();
           await Task.Delay(TimeSpan.FromMilliseconds(3000));

           AmmunitionInMagazine = MagazineSize;
        }

        public override void ShowGunUI()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Rifle : Gun
    {
        public override void Shoot(int x, int y, string direction)
        {
            if (AmmunitionInMagazine > 0)
                GameContainer.ProjectileList.Add(new Brra(x, y, direction));
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