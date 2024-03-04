using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Player
{
    public Rectangle car = new(60, 60, 100, 60);
    Vector2 carDirection = new();
    public float carRotation = new();
    public Vector2 carOrigin = new(50, 30);
    float speed;
    float acceleration = 0.01f;
    float maxSpeed = 20f;
    Vector2 speedVector = Vector2.Zero;
    float friction = 0.005f;


    private void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && speed < maxSpeed)
        {
            speed += acceleration;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && speed > -5)
        {
            speed -= acceleration;
        }

        if (speedVector.Length() > 0)
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
        if (speed > 0)
        {
            speed -= friction;
        }
        else if (speed < 0)
        {
            speed += friction;
        }

        carDirection.Y = MathF.Sin((MathF.PI / 180) * carRotation);
        carDirection.X = MathF.Cos((MathF.PI / 180) * carRotation);
        
        speedVector.X = carDirection.X * speed;
        speedVector.Y = carDirection.Y * speed;

        Console.WriteLine(speed);

        if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            speed = 0;
        }
    }

    public void Update()
    {
        Movement();
        car.X += speedVector.X * Raylib.GetFrameTime();
        car.Y += speedVector.Y * Raylib.GetFrameTime();

    }
}

