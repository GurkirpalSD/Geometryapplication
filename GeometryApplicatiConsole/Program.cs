using GeometryApplicationlibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

class Program
{
    static async Task Main(string[] args)
{
    var featureManagement = new Dictionary<string, string> {
        { "FeatureManagement:Square", "true"},
        { "FeatureManagement:Rectangle", "false"},
        { "FeatureManagement:Triangle", "true"}
    };

    IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(featureManagement)
        .Build();

    var services = new ServiceCollection();
    services.AddFeatureManagement(configuration);
    var serviceProvider = services.BuildServiceProvider();
    var featureManager = serviceProvider.GetRequiredService<IFeatureManagerSnapshot>();

    if (await featureManager.IsEnabledAsync("Square"))
    {
        Console.WriteLine("Enter the side length of the Square:");
        string? input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            double sideLength = double.Parse(input);
            var square = new Square(sideLength);
            Console.WriteLine($"Area of the Square: {square.CalculateArea()}");
            Console.WriteLine($"Perimeter of the Square: {square.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
   

    if (await featureManager.IsEnabledAsync("Rectangle"))
    {
         Console.WriteLine("Rectangle feature is enabled.");
        Console.WriteLine("Enter the length of the Rectangle:");
        string? lengthInput = Console.ReadLine();
        Console.WriteLine("Enter the width of the Rectangle:");
        string? widthInput = Console.ReadLine();

        if (!string.IsNullOrEmpty(lengthInput) && !string.IsNullOrEmpty(widthInput))
        {
            double length = double.Parse(lengthInput);
            double width = double.Parse(widthInput);
            var rectangle = new Rectangle(length, width);
            Console.WriteLine($"Area of the Rectangle: {rectangle.CalculateArea()}");
            Console.WriteLine($"Perimeter of the Rectangle: {rectangle.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
    else
    {
        Console.WriteLine("Rectangle feature is Disabled.");
    }


    if (await featureManager.IsEnabledAsync("Triangle"))
    {
        Console.WriteLine("Enter the lengths of the Triangle's sides (separated by commas):");
        string? sidesInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(sidesInput))
        {
            string[] sideLengths = sidesInput.Split(',');
            if (sideLengths.Length == 3)
            {
                double side1 = double.Parse(sideLengths[0]);
                double side2 = double.Parse(sideLengths[1]);
                double side3 = double.Parse(sideLengths[2]);
                var triangle = new Triangle(side1, side2, side3);
                Console.WriteLine($"Area of the Triangle: {triangle.CalculateArea()}");
                Console.WriteLine($"Perimeter of the Triangle: {triangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please provide exactly 3 side lengths separated by commas.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
    else
    {
        Console.WriteLine("Triangle feature is disabled.");
    }
}
}