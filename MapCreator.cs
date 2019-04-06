using System;

namespace Blone
{
    public class MapCreator
    {
        public void MapSettings()
        {
            Console.CursorVisible = false;
            HorizontalWalls(0, DevHelper.MapWidth+1, 1);
            VerticalWalls(1, DevHelper.MapHeight+1, 0);
            HorizontalWalls(0,DevHelper.MapWidth+1, DevHelper.MapHeight+1);
            VerticalWalls(1, DevHelper.MapHeight+2, DevHelper.MapWidth+1);
            HorizontalWalls(0, DevHelper.MapWidth/2, DevHelper.MapHeight/2);
            VerticalWalls(1,DevHelper.MapHeight/2, DevHelper.MapWidth/2+1);
            VerticalWalls(1, DevHelper.MapHeight, DevHelper.MapWidth/2+15);
        }
    
        public void HorizontalWalls(int from, int to, int y)
        {
            for (int i = from; i < to; i++)
            {
                var wall = new Wall(i, y);
                GameContainer.WallList.Add(wall);
                wall.Draw();
            }
        }

        public void VerticalWalls(int from, int to, int x)
        {
            for (int i = from; i < to; i++)
            {
                var wall = new Wall(x, i);
                GameContainer.WallList.Add(wall);
                wall.Draw();
            }
        }
    }
}