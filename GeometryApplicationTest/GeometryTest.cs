using GeometryApplicationlibrary;
namespace GeometryApplicatiTest;
[TestClass]
public class SquareTests
{
 [TestMethod]
    public void TestSquarePerimeter_Standard()
    {
        var square = new Square(10);
        var result = square.CalculatePerimeter();
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void TestSquareArea_Small()
    {
        var square = new Square(2);
        var result = square.CalculateArea();
        Assert.AreEqual(4, result);
    }
}

[TestClass]
public class RectangleTests
{
    [TestMethod]
    public void TestRectanglePerimeter_Large()
    {
        var rectangle = new Rectangle(15, 10);
        var result = rectangle.CalculatePerimeter();
        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void TestRectangleArea_Small()
    {
        var rectangle = new Rectangle(3, 2);
        var result = rectangle.CalculateArea();
        Assert.AreEqual(6, result);
    }
}

[TestClass]
public class TriangleTests
{
    [TestMethod]
    public void TestTrianglePerimeter_Large()
    {
        var triangle = new Triangle(13, 14, 15);
        var result = triangle.CalculatePerimeter();
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public void TestTrianglePerimeter_Small()
    {
        var triangle = new Triangle(1, 1, 1);
        var result = triangle.CalculatePerimeter();
        Assert.AreEqual(3, result);
    }
}
