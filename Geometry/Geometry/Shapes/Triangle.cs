namespace Geometry.Shapes;

public class Triangle : Shape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 ||
            b <= 0 ||
            c <= 0)
        {
            throw new ArgumentException("The sides of the triangle must be greater than 0");
        }

        if (a + b <= c ||
            a + c <= b ||
            b + c <= a)
        {
            throw new ArgumentException("The length of the two sides must be greater than the last one");
        }

        A = a;
        B = b;
        C = c;
    }

    public override double Calculate()
    {
        var halfOfPerimeter = (A + B + C) / 2;

        return Math.Sqrt(
            halfOfPerimeter * 
            (halfOfPerimeter - A) * 
            (halfOfPerimeter - B) *
            (halfOfPerimeter - C));
    }

    public bool IsRectangular()
    {
        Span<double> values = stackalloc double [3] {A, B, C};
        values.Sort();

        return Math.Abs(values[0] * values[0] + values[1] * values[1] - values[2] * values[2]) < 10E-10;
    }
}