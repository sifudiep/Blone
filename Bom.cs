namespace Blone
{
    public class Bom : Projectile
    {
        public Bom(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 50;
            Speed = 100;
            MaxDistance = 4;
            Type = DevHelper.Bom;
            Removed = false;
            Draw();
        }
    }
}