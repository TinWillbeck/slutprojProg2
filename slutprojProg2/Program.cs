using System.Numerics;
using Raylib_cs;


Player p = new();

Raylib.InitWindow(800,800, "TopDown Race");
Raylib.BeginDrawing();

while (Raylib.WindowShouldClose() == false)
{
    p.Update();
    int [,] layout = 
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,1},
            {1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,1},
            {1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,1},
            {1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,1},
            {1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,1},
            {1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},  
        };
        Raylib.ClearBackground(Color.WHITE);
        Color color = Color.WHITE;
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                if(layout[y,x] == 0)
                {
                    color = Color.WHITE;
                }
                if(layout[y,x] == 1)
                {
                    color = Color.RED;
                }
                if(layout[y,x] == 2)
                {
                    color = Color.BLACK;
                }

                Raylib.DrawRectangle(x*50,y*50,50,50, color);
            }
        }
        Raylib.DrawRectanglePro(p.car, p.carOrigin, p.carRotation, Color.GREEN);
    Raylib.EndDrawing();
}
Console.ReadLine();