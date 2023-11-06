using Geometry.Shapes;
using Xunit;

namespace Geometry.Tests.Shapes;

public class TriangleTests
{
    [Theory]
    [MemberData(nameof(NotAllSidesGreaterZero))]
    public void Construct_NotAllSidesGreaterZero_ShouldThrowArgumentException(double a, double b, double c)
    {
        // act
        var act = () => new Triangle(a, b, c);

        // assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("The sides of the triangle must be greater than 0", exception.Message);
    }
    
    [Theory]
    [MemberData(nameof(OneSideLongerTwoOther))]
    public void Construct_OneSideLongerTwoOther_ShouldThrowArgumentException(double a, double b, double c)
    {
        // act
        var act = () => new Triangle(a, b, c);

        // assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("The length of the two sides must be greater than the last one", exception.Message);
    }
    
    [Fact]
    public void Construct_CorrectSides_ShouldConstruct()
    {
        // arrange
        var a = 2;
        var b = 3;
        var c = 4;
        
        // act
        var triangle = new Triangle(a, b, c);

        // assert
        Assert.Equal(a, triangle.A);
        Assert.Equal(b, triangle.B);
        Assert.Equal(c, triangle.C);
    }
    
    [Fact]
    public void Calculate_CorrectCircle_ShouldReturnCorrectArea()
    {
        // arrange
        var a = 3;
        var b = 4;
        var c = 5;
        var triangle = new Triangle(a, b, c);
        
        // act
        var area = triangle.Calculate();
        
        // assert
        var expected = 6;
        Assert.Equal(expected, area, 10E-10);
    }
    
    [Fact]
    public void IsRectangular_RectangularCircle_ShouldReturnTrue()
    {
        // arrange
        var a = 3;
        var b = 4;
        var c = 5;
        var triangle = new Triangle(a, b, c);
        
        // act
        var isRectangular = triangle.IsRectangular();
        
        // assert
        Assert.True(isRectangular);
    }
    
    [Fact]
    public void IsRectangular_NotRectangularCircle_ShouldReturnTrue()
    {
        // arrange
        var a = 3;
        var b = 4;
        var c = 6;
        var triangle = new Triangle(a, b, c);
        
        // act
        var isRectangular = triangle.IsRectangular();
        
        // assert
        Assert.False(isRectangular);
    }
    
    public static IEnumerable<object[]> NotAllSidesGreaterZero() {
        yield return new object[] { -1D, 5D, 5D };
        yield return new object[] { 5D, -1D, 5D };
        yield return new object[] { 5D, 5D, -1D };
        yield return new object[] { -1D, 5D, -1D };
        yield return new object[] { 5D, -1D, -1D };
        yield return new object[] { -1D, -1D, 5D };
    }
    
    public static IEnumerable<object[]> OneSideLongerTwoOther() {
        yield return new object[] { 11D, 5D, 5D };
        yield return new object[] { 5D, 11D, 5D };
        yield return new object[] { 5D, 5D, 11D };
        yield return new object[] { 10D, 5D, 5D };
        yield return new object[] { 5D, 10D, 5D };
        yield return new object[] { 5D, 5D, 10D };
    }
}