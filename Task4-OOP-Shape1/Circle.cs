namespace Shape;

public class Circle : Shape
{
    public double Radius { get;private set;}

    public Circle(string name, double radius):base(name)
    {
        Radius=radius;
    }

    public override double CalculateArea()
    {
        return Math.PI*Radius*Radius;
    }
}
