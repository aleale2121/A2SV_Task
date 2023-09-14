using System;

namespace Shape;

public class Program
{
    public static void PrintShapeArea(Shape shape){
        Console.WriteLine($"Shape Name: {shape.Name}");
        Console.WriteLine($"Area: {shape.CalculateArea()} \n");
    }

    public static void Main(){

        Circle circle = new Circle("Circle",2.0);
        Rectangle rectangle = new Rectangle("Rectangle",2.0,3.0);
        Triangle triangle = new Triangle("Triangle",3.0,3.0);

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
