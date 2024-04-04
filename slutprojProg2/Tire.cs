using Raylib_cs;

public abstract class Tire
{
    protected float maxRotation = 5;
    protected float dropoffRate = 15f;
    protected float rotationSpeed;

    public float turnSpeed(float speed)
    {
        if (speed != 0)
        {
            rotationSpeed = maxRotation / speed * dropoffRate;
            rotationSpeed = Math.Clamp(rotationSpeed, -maxRotation, maxRotation);
        }
        Console.WriteLine(rotationSpeed);
        return rotationSpeed;
    }
}

class TestTire : Tire
{

}

class BadTire : Tire
{
    public BadTire()
    {
        maxRotation = 1;
        dropoffRate = 20;
    }
}

class MediumTire : Tire
{
    public MediumTire()
    {
        maxRotation = 5;
        dropoffRate = 10;
    }
}

class GoodTire : Tire
{
    public GoodTire()
    {
        maxRotation = 10;
        dropoffRate = 5;
    }
}