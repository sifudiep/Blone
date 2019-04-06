using System;

namespace Blone
{
    public class RifleAmmo : Projectile
    {
        public RifleAmmo(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 7;
            Speed = 100;
            MaxDistance = 12;
            Type = DevHelper.RifleAmmo;
            Removed = false;
            Draw();
        }
    }
}