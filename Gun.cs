using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Blone
{
    public abstract class Gun
    {
        public string Type;
        public int MagazineSize;
        public int AmmunitionInMagazine;
        public int RoundsPerKSeconds;
        public int ReloadMilliseconds;
        public string AmmoType;
        public bool Reloading = false;
        public Stopwatch ShootTimer = new Stopwatch();
        public Stopwatch ReloadTimer = new Stopwatch();

        public void Shoot(int x, int y, string direction)
        {
            if (Reloading == false && AmmunitionInMagazine > 0 && ShootTimer.ElapsedMilliseconds > RoundsPerKSeconds)
            {
                switch (AmmoType)
                {
                    case DevHelper.Bullet:
                        GameContainer.ProjectileList.Add(new Bullet(x, y, direction));
                        break;
                    case DevHelper.RifleAmmo:
                        GameContainer.ProjectileList.Add(new RifleAmmo(x, y, direction));
                        break;
                    case DevHelper.ShotgunShell:
                        GameContainer.ProjectileList.Add(new ShotgunShell(x, y, direction));
                        break;
                }

                ShootTimer.Restart();
                AmmunitionInMagazine--;
                GameContainer.UserInterface.UpdateAmmo();
            }
        }
        public async void Reload()
        {
            ReloadTimer.Start();
            Reloading = true;
            await Task.Delay(TimeSpan.FromMilliseconds(ReloadMilliseconds));
            
            AmmunitionInMagazine = MagazineSize;
            Reloading = false;

        }
    }
}