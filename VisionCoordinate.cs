using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public class VisionCoordinate
    {
        public int X;
        public int Y;
        public int Row;
        public bool Infected;
        public bool InsideWall;
        public bool Essential;
        public VisionCoordinate FirstVictim;
        public VisionCoordinate SecondVictim;
    }
}