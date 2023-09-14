namespace Shape;

public class Triangle : Shape
{
    public double BaseLength {get;private set;}
    public double TriangleHeight {get;private set;}

    public Triangle(string name, double baseLength, double height):base(name){
        BaseLength=baseLength;
        TriangleHeight=height;
    }

    public override double CalculateArea(){
        return (BaseLength * TriangleHeight) / 2;
    }
}
