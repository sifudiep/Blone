using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public abstract class Gun
    {
        public int MagazineSize;
        public int AmmunitionInMagazine;
        public int RoundsPerSecond;

        public abstract void Shoot(int x, int y, string direction);
        public abstract void Reload();
        public abstract void ShowGunUI();
    }
}