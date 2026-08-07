namespace Bean.Entites;

public struct Vector2
{
    public static readonly Vector2 Zero = new(0, 0);


    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public readonly float Magnitude => (float) Math.Sqrt(X * X + Y * Y);

    public readonly Vector2 Normalized()
    {
       var magnitude = Magnitude;
        if (magnitude > 0)
        {
            return new Vector2(X / magnitude, Y / magnitude);
        }

        return Zero;   


    }   
}
