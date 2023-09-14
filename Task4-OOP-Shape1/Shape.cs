using System;

namespace Shape;

public class Shape
{
    public string Name{get; private set;}

    public Shape(string name){
        Name=name;
    }

    public virtual double CalculateArea(){
        return 0;
    }
}
