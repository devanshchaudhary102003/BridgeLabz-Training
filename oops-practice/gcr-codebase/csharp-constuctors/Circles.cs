using System;
public class Circle
{
    public double Radius;

    public Circle()
    {
        Radius = 5;
    }

    //Parameterized Constructor
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public void Display()
    {
       Console.WriteLine("Radius:"+Radius);
       Console.WriteLine("Area:"+GetArea()); 
    }
}
public class Circles
{
    static void Main(string[] args)
    {
        Circle c1 = new Circle();
        c1.Display();

        Circle c2 = new Circle(5);
        c2.Display();
    }
}