using Raylib_cs;

public abstract class Tire
{
    protected float maxRotation = 5;
    protected float dropoffRate = 15f;
    protected float sandGripVar = 3;
    protected float rotationSpeed;

    public float TurnSpeed(float speed)
    {
        // medans speed är mer/ lika med 10
        if (speed >= 10)
        {
            // sätt rotationspeed till maxrotation delat med speed gånger dropoffrate, detta för att rotationspeed ska minska när speed ökar
            // rotationspeed clampas för att det hände ibland att det delades med noll och spelet pajade
            rotationSpeed = maxRotation / speed * dropoffRate;
            rotationSpeed = Math.Clamp(rotationSpeed, -maxRotation, maxRotation);
        }
        return rotationSpeed;
    }
    public float GetSandGrip()
    {
        return sandGripVar;
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
        sandGripVar = 10;
    }
}

class MediumTire : Tire
{
    public MediumTire()
    {
        maxRotation = 5;
        dropoffRate = 10;
        sandGripVar = 5;
    }
}

class GoodTire : Tire
{
    public GoodTire()
    {
        maxRotation = 15;
        dropoffRate = 5;
        sandGripVar = 2;
    }
}