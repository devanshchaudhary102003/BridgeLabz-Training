using System;
public class Circle
{
    public double radius;
    public void GetRadius()
    {
        Console.WriteLine("Enters Radius:");
        radius = Convert.ToDouble(Console.ReadLine());
    }
    public void DisplayArea()
    {
        double Area = Math.PI * radius * radius;

        Console.WriteLine("Area of Circle:"+Area);
    }

    public void DisplayCircumference()
    {

        double Circumference = 2 * Math.PI * radius;

        Console.WriteLine("Circumference of Circle:"+Circumference);
    }
}
public class AreaOfCircle
{
    static void Main(string[] args)
    {
        Circle circle = new Circle();
        circle.GetRadius();
        circle.DisplayArea();
        circle.DisplayCircumference();
    }
}