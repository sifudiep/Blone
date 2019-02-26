using System;
using System.Diagnostics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using System.Xml;

namespace Blone
{
    public class Pistol : Gun
    {
        public Pistol()
        {
            MagazineSize = 10;
            AmmunitionInMagazine = 10;
            RoundsPerKSeconds = 500;
            ReloadMilliseconds = 3000;
            AmmoType = DevHelper.Bullet;
            ShootTimer.Start();
        }
        public override void UpdateGunUI()
        {
            throw new System.NotImplementedException();
        }
    }
}