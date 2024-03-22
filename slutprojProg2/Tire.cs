using Raylib_cs;

public abstract class Tire
{
    protected float maxRotation = 5;
    protected float dropoffRate = 1f;
    protected float rotationSpeed;

    public float turnSpeed(float speed)
    {
        rotationSpeed = MathF.Pow(speed, dropoffRate) * 0.1f;
        rotationSpeed = Math.Clamp(rotationSpeed, -maxRotation, maxRotation);
        Console.WriteLine(rotationSpeed);
        return rotationSpeed;
    }
}

class TestTire : Tire
{

}