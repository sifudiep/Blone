using System.Reflection;

namespace Blone
{
    public static class DevHelper
    {
        public const string Up = "Up";
        public const string Down = "Down";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Pistol = "Pistol";
        public const string Rifle = "Rifle";
        public const string Shotgun = "Shotgun";
        public const string Bullet = "Bullet";
        public const string RifleAmmo = "RifleAmmo";
        public const string ShotgunShell = "ShotgunShell";
        public const int StartHealth = 100;
        public const int EnemyDamage = 20;
        public const int MapWidth = 50;
        public const int MapHeight = 20;
        public const int XHealth = MapWidth-20;
        public const int YHealth = MapHeight + 2;
        public const int XAmmo = 0;
        public const int YAmmo = MapHeight + 2;
        public const int XGameOver = 0;
        public const int YGameOver = 0;
        public const int XScore = 22;
        public const int YScore = 0;
        public const int EnemyLimit = 50;
        public const int EnemyMovesPerKSeconds = 1250;
        public const int ScorePerKill = 1;
        public const string OutOfBounds = "OutOfBounds";
        public const string NoCollision = "NoCollision";
        public const string WallCollision = "WallCollision";
        public const string EnemyCollision = "EnemyCollision";
        public const int XEyeOne = 10;
        public const int YEyeOne = 3;
        public const int XEyeTwo = 30;
        public const int YEyeTwo = 3;
        public const int XFrown = 10;
        public const int YFrown = 13;
    }
}