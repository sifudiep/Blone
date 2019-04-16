using System;
using System.Diagnostics;

namespace Blone
{
    public class Bullet : Projectile
    {

        /// <summary>
        /// Sets fields in projectile for the bullet derivative class. 
        /// </summary>
        /// <param name="x">X coordinate the projectile should spawn in.</param>
        /// <param name="y">Y coordinate the projectile should spawn in.</param>
        /// <param name="direction">Direction the projectile should move in.</param>
        public Bullet(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 10;
            Speed = 50;
            MaxDistance = 10;
            Type = DevHelper.Bullet;
            Removed = false;
            Draw();
        }
    }
}