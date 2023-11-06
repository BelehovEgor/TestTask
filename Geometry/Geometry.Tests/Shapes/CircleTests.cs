using Geometry.Shapes;
using Xunit;

namespace Geometry.Tests.Shapes;

public class CircleTests
{
    [Theory]
    [MemberData(nameof(IncorrectRadius))]
    public void Construct_RadiusLessOrEqualZero_ShouldThrowArgumentException(double radius)
    {
        // act
        var act = () => new Circle(radius);

        // assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Radius should be greater that 0", exception.Message);
    }
    
    [Fact]
    public void Construct_RadiusGreaterThanZero_ShouldConstruct()
    {
        // arrange
        var radius = 5;
        
        // act
        var circle = new Circle(radius);

        // assert
        Assert.Equal(radius, circle.Radius);
    }
    
    [Fact]
    public void Calculate_CorrectCircle_ShouldReturnCorrectArea()
    {
        // arrange
        var radius = 5;
        var circle = new Circle(radius);
        
        // act
        var area = circle.Calculate();
        
        // assert
        var expected = radius * radius * double.Pi;
        Assert.Equal(expected, area, 10E-10);
    }
    
    public static IEnumerable<object[]> IncorrectRadius() {
        yield return new object[] { -1D };
        yield return new object[] { 0D };
    }
}