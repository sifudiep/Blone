namespace Blone
{
    public class ShotgunShell : Projectile
    {
        public ShotgunShell(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 50;
            Speed = 100;
            MaxDistance = 4;
            Type = DevHelper.ShotgunShell;
            Removed = false;
            Draw();
        }
    }
}