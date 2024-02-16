using System.Numerics;
using Raylib_cs;
public class Player
{
    public Rectangle car = new(60,60,60,100);
    Vector2 carMovement = new();
    public float carRotation = new();
    public Vector2 carOrigin = new(30,50);
    float speed = 0.1f;
    float friction = 0.02f;

    

    public void Movement()
    {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        carMovement -= 1 * speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
        carMovement += 1 * speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        carRotation -= 0.1f;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        carRotation += 0.1f;
    }
    car.Y = carMovement;

    
    }
}
