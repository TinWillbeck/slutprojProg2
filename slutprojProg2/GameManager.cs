using Raylib_cs;
using System.Numerics;

public class GameManager
{
    Player p = new(new LargeEngine(), new GoodTire());
    Level l = new();

    public GameManager()
    {
        Raylib.InitWindow(800,800, "TopDown Race");
        Raylib.SetTargetFPS(60);
    }

    public void Logic()
    {

        p.Update();
       
        foreach (Vector2 corner in p.GetCorners())
        {
            foreach (Rectangle wall in l.walls)
            {
                if (Raylib.CheckCollisionPointRec(corner, wall))
                {
                    p.Collision();
                }
            }
            foreach (Rectangle sand in l.sand)
            {
                if (Raylib.CheckCollisionPointRec(corner, sand))
                {
                    p.SandCollision();
                }
            }
        }
        
    }

    public void DrawScene()
    {

        Raylib.BeginDrawing();
        for (int i = 0; i < l.walls.Count; i++)
        {
            Raylib.DrawRectangleRec(l.walls[i], Color.RED);


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
}
