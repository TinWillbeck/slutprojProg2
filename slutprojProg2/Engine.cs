public abstract class Engine
{
    protected float maxSpeed =  50;
    protected float acceleration = 1.5f;
    public float GetSpeed()
    {
        return maxSpeed;
    }
    public float GetAcceleration()
    {
        return acceleration;
    }
}

class SmallEngine : Engine
{
    
}
class MediumEngine : Engine
{
    public MediumEngine()
    {
        maxSpeed = 100;
        acceleration = 2;
    }
}
class LargeEngine : Engine
{
    public LargeEngine()
    {
        maxSpeed = 130;
        acceleration = 4;
    }
}