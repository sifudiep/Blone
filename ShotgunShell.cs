namespace Blone
{
    public class ShotgunShell : Projectile
    {
        /// <summary>
        /// Sets fields in projectile for the ShotgunShell derivative class. 
        /// </summary>
        /// <param name="x">X coordinate the projectile should spawn in.</param>
        /// <param name="y">Y coordinate the projectile should spawn in.</param>
        /// <param name="direction">Direction the projectile should move in.</param>
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