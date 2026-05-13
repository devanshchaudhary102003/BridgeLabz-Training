using System;
//Interface
interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

class Bird
{
    public string BirdName;

    public Bird(string birdName)
    {
        BirdName = birdName;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Bird Name: "+BirdName);
    }
}

class Eagle : Bird, IFlyable
{
    public Eagle(string birdName):base(birdName){}

    public void Fly()
    {
        Console.WriteLine("Eagle is Fly");
    }
}

class Sparrow : Bird, IFlyable
{
    public Sparrow(string birdName):base(birdName){}

    public void Fly()
    {
        Console.WriteLine("Sparrow is Fly");
    }
}

class Duck : Bird, ISwimmable
{
    public Duck(string birdName):base(birdName){}

    public void Swim()
    {
        Console.WriteLine("Duck is Swim");
    }
}

class Penguin : Bird, ISwimmable
{
    public Penguin(string birdName):base(birdName){}

    public void Swim()
    {
        Console.WriteLine("Penguin is Swim");
    }
}

class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string birdName):base(birdName){}

    public void Swim()
    {
        Console.WriteLine("Seagull is Swim");
    }
    public void Fly()
    {
        Console.WriteLine("Seagull is Fly");
    }
}
class BirdSanctuarySystem
{
    static void Main(string[] args)
    {
        //Array
        Bird[] bird = new Bird[5];

        bird[0] = new Eagle("Eagle");
        bird[1] = new Sparrow("Sparrow");
        bird[2] = new Duck("Duck");
        bird[3] = new Penguin("Penguin");
        bird[4] = new Seagull("Seagull");

        for(int i = 0; i < bird.Length; i++)
        {
            bird[i].DisplayDetails();

            if(bird[i] is IFlyable)
            {
                IFlyable flyable = (IFlyable)bird[i];
                flyable.Fly();
            }

            if(bird[i] is ISwimmable)
            {
                ISwimmable swimmable = (ISwimmable)bird[i];
                swimmable.Swim();
            }
        }
    }
}