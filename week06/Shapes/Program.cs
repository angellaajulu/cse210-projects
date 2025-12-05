using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2.5));

        // Display areas using polymorphism
        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Shape Color: {s.GetColor()}");
            Console.WriteLine($"Area: {Math.Round(s.GetArea(), 2)}\n");
        }
    }
}