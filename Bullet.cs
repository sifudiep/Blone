using System;
using System.Diagnostics;

namespace Blone
{
    public class Bullet : Projectile
    {
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