namespace Geometry.Shapes;

public sealed class Circle : Shape
{
    public double Radius { get; init; }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius should be greater that 0");
        }

        Radius = radius;
    }

    public override double Calculate()
    {
        return double.Pi * Radius * Radius;
    }
}