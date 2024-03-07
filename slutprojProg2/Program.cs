using System.Numerics;
using Raylib_cs;

Player p = new();
Level l = new();
Raylib.InitWindow(800,800, "TopDown Race");
Raylib.SetTargetFPS(60);

Rectangle r = new();



while (Raylib.WindowShouldClose() == false)
{
    p.Update();

    Raylib.BeginDrawing();
    for (int i = 0; i < l.walls.Count; i++)
    {
        Raylib.DrawRectangleRec(l.walls[i], Color.RED);
        if (Raylib.CheckCollisionRecs(p.car, l.walls[i]))
        {
            
        }
    }
    for (int i = 0; i < l.sand.Count; i++)
    {
        Raylib.DrawRectangleRec(l.sand[i], Color.BEIGE);
    }
    for (int i = 0; i < l.track.Count; i++)
    {
        Raylib.DrawRectangleRec(l.track[i], Color.BLACK);
    }
    // Raylib.DrawRectangle(x*50,y*50,50,50, color);
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawRectanglePro(p.car, p.CarOrigin(), p.CarRotation(), Color.GREEN);
    Raylib.EndDrawing();
}


