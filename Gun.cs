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
                var possibleX = x;
                var possibleY = y;
                var notInsideWall = true;
                switch (direction)
                {
                    case DevHelper.Up:
                        possibleY -= 1;
                        break;
                    case DevHelper.Down:
                        possibleY += 1;
                        break;
                    case DevHelper.Right:
                        possibleX += 1;
                        break;
                    case DevHelper.Left:
                        possibleX -= 1;
                        break;
                }

                for (int i = 0; i < GameContainer.WallList.Length; i++)
                {
                    if (GameContainer.WallList[i].X == possibleX && GameContainer.WallList[i].Y == possibleY)
                        notInsideWall = false;
                }
                
                // If statement inside if statement to limit WallList looping, to minimize performance loss. 
                if (notInsideWall)
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
        }
        public async void Reload()
        {
            ReloadTimer.Start();
            Reloading = true;
            await Task.Delay(TimeSpan.FromMilliseconds(ReloadMilliseconds));

            AmmunitionInMagazine = MagazineSize;
            GameContainer.UserInterface.UpdateAmmo();
            Reloading = false;

        }
    }
}