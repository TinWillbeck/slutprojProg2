﻿using Raylib_cs;
public class Level
{
    public List<Rectangle> walls = new();
    public List<Rectangle> sand = new();
    public List<Rectangle> track = new();

    public Level()
    {
        // en array som används som banans layout, där de olika siffrorna beskriver olika "tiles"
        int [,] layout =
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
        // lägger in de olika tilsen i respektive listor
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                if(layout[y,x] == 0)
                {
                    Rectangle s = new(x * 50,y * 50, 50, 50);
                    sand.Add(s);
                }
                if(layout[y,x] == 1)
                {
                    Rectangle w = new(x * 50,y * 50, 50, 50);
                    walls.Add(w);
                }
                if(layout[y,x] == 2)
                {
                    Rectangle t = new(x * 50,y * 50, 50, 50);
                    track.Add(t);
                }
            }
        }
    }
}
