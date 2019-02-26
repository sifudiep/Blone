using System;

namespace Blone
{
    public class Brra : Projectile
    {
        public Brra(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 7;
            Speed = 100;
            MaxDistance = 12;
            Type = DevHelper.Brra;
            Removed = false;
            Draw();
        }
    }
}