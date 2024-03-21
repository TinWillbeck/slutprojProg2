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
    // konstruktor som gör att man kan sätta motor och annat när man instansierar player
    public Player(Engine engine)
    {
        // sätter bilens accelerations och toppfartsvärden till motorns respektive värden
        acceleration = engine.GetAcceleration();
        maxSpeed = engine.GetSpeed();

    }
    // metod som har hand om bilens rörelse framåt
    private void Movement()
    {
        // om man håller in W så accelererar bilen upp till sin toppfart
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && speed < maxSpeed)
        {
            speed += acceleration;
        }
        // om man håller in S så accelererar bilen bakåt till en tredjededel av sin maxfart
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && speed > maxSpeed / 3)
        {
            speed -= acceleration;
        }

        GetRotation();
        //carDirection X är cosinus av carrotation omvandlat till radianer
        //carDirection Y är sinus av carrotation omvandlat till radianer
        carDirection.X = MathF.Cos((MathF.PI / 180) * carRotation);
        carDirection.Y = MathF.Sin((MathF.PI / 180) * carRotation);

        // speedvector X och Y är respektive carDirection X oxh Y multiplicerad med speed
        speedVector.X = carDirection.X * speed;
        speedVector.Y = carDirection.Y * speed;

        // debug funktion som teleporterar bilen till mitten av skärmen
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            car.X = 400;
            car.Y = 400;
        }

    }
    // metod som roterar bilen
    void GetRotation()
    {
        // kollar om bilen rör på sig
        if (speedVector.Length() > 0)
        {
            // om man håller in A roteras bilen åt vänster
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                carRotation -= rotationSpeed;
                if (carRotation < 0)
                {
                    carRotation += 360;
                }
            }
            // om man håller in D så roterar bilen åt höger
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                carRotation += rotationSpeed;
                if (carRotation > 360)
                {
                    carRotation -= 360;
                }
            }
        }
    }

    // metod som räknar ut bilens hörn och lägger in dem i en lista med vektorer
    public Vector2[] GetCorners()
    {
        // vektorns X 
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

        return new Vector2[] { topLeft, topRight, bottomRight, bottomLeft };
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
        if (speed > 0)
        {
            speed -= friction;
        }
        else if (speed < 0)
        {
            speed += friction;
        }

    }
}

