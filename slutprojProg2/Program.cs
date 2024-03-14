using System.Numerics;
using Raylib_cs;


Player p = new(new SmallEngine());
Level l = new();
Raylib.InitWindow(800,800, "TopDown Race");
Raylib.SetTargetFPS(60);

while (Raylib.WindowShouldClose() == false)
{
    p.Update();

    Raylib.BeginDrawing();
    for (int i = 0; i < l.walls.Count; i++)
    {
        Raylib.DrawRectangleRec(l.walls[i], Color.RED);
        if (Raylib.CheckCollisionRecs(p.GetPlayer(), l.walls[i]))
        {
            p.Collision();
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
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawRectanglePro(p.GetPlayer(), p.CarOrigin(), p.CarRotation(), Color.GREEN);
    Raylib.EndDrawing();
}


