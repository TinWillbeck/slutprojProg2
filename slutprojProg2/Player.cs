using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Player
{
    Rectangle car = new(150, 150, 50, 30);
    Vector2 carDirection = new();
    float carRotation = new();
    Vector2 carOrigin = new(25, 15);
    float speed;
    float acceleration;
    float maxSpeed;
    float rotationSpeed = 4f;
    Vector2 speedVector = Vector2.Zero;
    float friction = 1.5f;
    public Player(Engine engine)
    {
        acceleration = engine.GetAcceleration();
        maxSpeed = engine.GetSpeed();

    }

    private void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && speed < maxSpeed)
        {
            speed += acceleration;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && speed > -40)
        {
            speed -= acceleration;
        }

        if (speedVector.Length() > 0)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                carRotation -= rotationSpeed;
                if (carRotation < 0)
                {
                    carRotation += 360;
                }
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                carRotation += rotationSpeed;
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


        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            car.X = 400;
            car.Y = 400;
        }
    }

    public Vector2[] GetCorners()
    {
        Vector2 topRight = new()
        {
            X = car.X + carOrigin.Y / 1.5f * MathF.Cos(carRotation) - carOrigin.X / 1.5f * MathF.Sin(carRotation),
            Y = car.Y + carOrigin.Y / 1.5f * MathF.Sin(carRotation) + carOrigin.X / 1.5f * MathF.Cos(carRotation)
        };
        Vector2 topLeft = new()
        {
            X = car.X - carOrigin.Y / 1.5f * MathF.Cos(carRotation) - carOrigin.X / 1.5f * MathF.Sin(carRotation),
            Y = car.Y - carOrigin.Y / 1.5f * MathF.Sin(carRotation) + carOrigin.X / 1.5f * MathF.Cos(carRotation)
        };
        Vector2 bottomRight = new()
        {
            X = car.X + carOrigin.Y / 1.5f * MathF.Cos(carRotation) + carOrigin.X / 1.5f * MathF.Sin(carRotation),
            Y = car.Y + carOrigin.Y / 1.5f * MathF.Sin(carRotation) - carOrigin.X / 1.5f * MathF.Cos(carRotation)
        };
        Vector2 bottomLeft = new()
        {
            X = car.X - carOrigin.Y / 1.5f * MathF.Cos(carRotation) + carOrigin.X / 1.5f * MathF.Sin(carRotation),
            Y = car.Y - carOrigin.Y / 1.5f * MathF.Sin(carRotation) - carOrigin.X / 1.5f * MathF.Cos(carRotation)
        };

        return new Vector2[] {topLeft, topRight, bottomRight, bottomLeft};        
    }
    public void Collision()
    {
        speed -= speed * 2;
    }

    public float CarRotation()
    {
        return carRotation;
    }

    public Vector2 CarOrigin()
    {
        return carOrigin;
    }

    public Rectangle GetPlayer()
    {
        return car;
    }

    public void Update()
    {
        Movement();
        car.X += speedVector.X * Raylib.GetFrameTime();
        car.Y += speedVector.Y * Raylib.GetFrameTime();

    }
}

