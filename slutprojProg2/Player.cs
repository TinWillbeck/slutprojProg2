using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Player
{
    public Rectangle car = new(60, 60, 100, 60);
    Vector2 carDirection = new();
    public float carRotation = new();
    public Vector2 carOrigin = new(50, 30);
    float speed = 0.01f;
    float maxSpeed = 1f;
    Vector2 currentSpeed = Vector2.Zero;
    float friction = 0.02f;



    private void Movement()
    {
        if (currentSpeed.Length() > 0)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                carRotation -= 0.1f;
                if (carRotation < 0)
                {
                    carRotation += 360;
                }
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                carRotation += 0.1f;
                if (carRotation > 360)
                {
                    carRotation -= 360;
                }
            }
        }

        // När rotationen ändras så ska riktningen bilen åker ändras,

        carDirection.Y = MathF.Sin((MathF.PI / 180) * carRotation) * speed;
        carDirection.X = MathF.Cos((MathF.PI / 180) * carRotation) * speed;
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            currentSpeed.X += carDirection.X;
            currentSpeed.Y += carDirection.Y;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            currentSpeed.X -= carDirection.X;
            currentSpeed.Y -= carDirection.Y;
        }

        Console.WriteLine(currentSpeed);


        if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            currentSpeed = Vector2.Zero;
        }
    }

    public void Update()
    {
        Movement();
        car.X += currentSpeed.X * Raylib.GetFrameTime();
        car.Y += currentSpeed.Y * Raylib.GetFrameTime();
    
    }
}

