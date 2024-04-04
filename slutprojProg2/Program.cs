using System.Numerics;
using Raylib_cs;


GameManager g = new();


while (Raylib.WindowShouldClose() == false)
{
    g.Logic();
    g.DrawScene();
    // Raylib.BeginDrawing();
    // for (int i = 0; i < l.walls.Count; i++)
    // {
    //     Raylib.DrawRectangleRec(l.walls[i], Color.RED);

    //     foreach (Vector2 corner in p.GetCorners())
    //     {
    //         if (Raylib.CheckCollisionPointRec(corner, l.walls[i]))
    //         {
    //             p.Collision();
    //         }
    //     }
    // }

    // for (int i = 0; i < l.sand.Count; i++)
    // {
    //     Raylib.DrawRectangleRec(l.sand[i], Color.BEIGE);
    // }

    // for (int i = 0; i < l.track.Count; i++)
    // {
    //     Raylib.DrawRectangleRec(l.track[i], Color.BLACK);
    // }
    // Raylib.ClearBackground(Color.WHITE);
    // Raylib.DrawRectanglePro(p.GetPlayer(), p.CarOrigin(), p.CarRotation(), Color.GREEN);
    // Raylib.EndDrawing();
}


