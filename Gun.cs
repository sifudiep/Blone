using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public abstract class Gun
    {
        public int MagazineSize;
        public int AmmunitionInMagazine;
        public int RoundsPerSecond;

        public abstract void Shoot(int x, int y, string direction);
        public abstract void Reload();
        public abstract void ShowGunUI();
    }

    public class Pistol : Gun
    {
        public Pistol()
        {
            MagazineSize = 10;
            AmmunitionInMagazine = 10;
            RoundsPerSecond = 2;
        }
        public override void Shoot(int x, int y, string direction)
        {
            if (AmmunitionInMagazine > 0)
            {
                new Bullet(x, y, direction);
            }
        }

        public override void Reload()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowGunUI()
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract class Projectile
    {
        public Projectile(int x, int y, string direction)
        {
            Direction = direction;
            switch (direction)
            {
                case DevHelper.DIRECTION_UP:
                    X = x;
                    Y = y - 1;
                    break;
                case DevHelper.DIRECTION_DOWN:
                    X = x;
                    Y = y + 1;
                    break;
                case DevHelper.DIRECTION_LEFT:
                    X = x - 1;
                    Y = y;
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    X = x + 1;
                    Y = y;
                    break;
            }
        }

        public int X;
        public int Y;
        public int Damage;
        public int Speed;
        public string Direction;
        public abstract void Move();
        public abstract void Erase();
        public abstract void Draw();
    }

    public class Bullet : Projectile
    {
        public Bullet(int x, int y, string direction) : base(x, y, direction)
        {
            Damage = 10;
            Speed = 2;
            Draw();
        }

        public override void Move()
        {
            switch (Direction)
            {
                case DevHelper.DIRECTION_UP:
                    Erase();
                    Y = Y + 1;
                    Draw();
                    break;
                case DevHelper.DIRECTION_DOWN:
                    Erase();
                    Y = Y - 1;
                    Draw();
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    Erase();
                    X = X + 1;
                    Draw();
                    break;
                case DevHelper.DIRECTION_LEFT:
                    Erase();
                    X = X - 1;
                    Draw();
                    break;
            }
        }

        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("#");
        }
    }
}