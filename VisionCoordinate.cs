using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Blone
{
    public class VisionCoordinate
    {
        public int X;
        public int Y;
        public int Row;
        public bool Visible = true;
        public bool Origin = false;
        public VisionCoordinate Infecter = null;

        // Spreads infection to VisionCoordinate above it and to the side of it.
        public void Infect(List<VisionCoordinate> visionCoordinates, int visionCoordinateTracker)
        {
            if (visionCoordinates[visionCoordinateTracker].Y < 3)
                Row = 0;
            else if (visionCoordinates[visionCoordinateTracker].Y < 8
                     && visionCoordinates[visionCoordinateTracker].Y > 2)
                Row = 1;
            else if (visionCoordinates[visionCoordinateTracker].Y < 15
                     && visionCoordinates[visionCoordinateTracker].Y > 7)
                Row = 2;
            else if (visionCoordinates[visionCoordinateTracker].Y > 14)
                Row = 3;
            
            // right
            if (Row < 3)
            {
                if (visionCoordinates[visionCoordinateTracker].X > X)
                {
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Visible = false;
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Infecter = this;

                    visionCoordinates[visionCoordinateTracker + (3 + 2 * Row)].Y = 1;
                    visionCoordinates[visionCoordinateTracker + (3 + 2 * Row)].Infecter = this;

                }
                // left
                else if (visionCoordinates[visionCoordinateTracker].X < X)
                {
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Visible = false;
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Infecter = this;

                    visionCoordinates[visionCoordinateTracker + (5 + 2 * Row)].Visible = false;
                    visionCoordinates[visionCoordinateTracker + (5 + 2 * Row)].Infecter = this;
                }
                // middle
                else if (visionCoordinates[visionCoordinateTracker].X == X)
                {
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Visible = false;
                    visionCoordinates[visionCoordinateTracker + (4 + 2 * Row)].Infecter = this;
                }    
            }
                                                                                    
        }

        public string CheckInfection()
        {
            if (Visible == false && Origin == false)
            {
                if (Infecter.Visible && Infecter.Origin)
                    return DevHelper.NotInfected;
                if (Infecter.Visible == false && Infecter.Origin == false) 
                    return DevHelper.Infected;
                if (Infecter.Visible)
                    return DevHelper.NotInfected;
                
                return DevHelper.Infected;
            }

            return DevHelper.NotInfected;
        }
    }
}