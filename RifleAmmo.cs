using System;

namespace Blone
{
    public class RifleAmmo : Projectile
    {
        /// <summary>
        /// Sets fields in projectile for the RifleAmmo derivative class. 
        /// </summary>
        /// <param name="x">X coordinate the projectile should spawn in.</param>
        /// <param name="y">Y coordinate the projectile should spawn in.</param>
        /// <param name="direction">Direction the projectile should move in.</param>
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