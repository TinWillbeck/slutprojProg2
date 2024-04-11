using Raylib_cs;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

public class GameManager
{
    // skapa en spelare och en level
    Player p = new(new LargeEngine(), new GoodTire());
    Level l = new();

    // skapar fönstret
    public GameManager()
    {
        Raylib.InitWindow(800,800, "TopDown Race");
        Raylib.SetTargetFPS(60);
    }

    // metod som kör spelets logik
    public void Logic()
    {
        p.Update();
       
        //går igenom alla bilens hörn
        foreach (Vector2 corner in p.GetCorners())
        {
            // går igenom alla väggar
            foreach (Rectangle wall in l.walls)
            {
                // om en vägg och ett av bilens hörn överlappar körs spelarens kollision
                if (Raylib.CheckCollisionPointRec(corner, wall))
                {
                    p.Collision();
                }
            }
            // går igenom alla sand
            foreach (Rectangle sand in l.sand)
            {
                // om en sand och ett av bilens hörn överlappar så körs spelarens sandkollision
                if (Raylib.CheckCollisionPointRec(corner, sand))
                {
                    p.SandCollision();
                }
            }
            // går igenom alla track
            foreach (Rectangle track in l.track)
            {
                // om en sand och ett av bilens hörn överlappar så körs spelarens sandkollision
                if (Raylib.CheckCollisionPointRec(corner, track))
                {
                    p.TrackCollision();
                }
            }
        }
    }

    // metod som ritar ut scenen
    public void DrawScene()
    {

        Raylib.BeginDrawing();
        // ritar ut alla väggar
        for (int i = 0; i < l.walls.Count; i++)
        {
            Raylib.DrawRectangleRec(l.walls[i], Color.RED);
        }

        // ritar ut all sand
        for (int i = 0; i < l.sand.Count; i++)
        {
            Raylib.DrawRectangleRec(l.sand[i], Color.BEIGE);
        }

        // ritar ut all asfalt
        for (int i = 0; i < l.track.Count; i++)
        {
            Raylib.DrawRectangleRec(l.track[i], Color.BLACK);
        }
        // ritar bakgrunden (inte så nödvändigt kanske)
        Raylib.ClearBackground(Color.WHITE);
        // ritar ut spelaren
        Raylib.DrawRectanglePro(p.GetPlayer(), p.CarOrigin(), p.CarRotation(), Color.GREEN);
        Raylib.EndDrawing();
    }
}
