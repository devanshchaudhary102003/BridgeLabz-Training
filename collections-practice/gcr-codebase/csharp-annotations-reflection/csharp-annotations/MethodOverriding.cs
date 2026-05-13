using System;
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal Make a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog Make a sound");
    }
}
class MethodOverriding
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.MakeSound();
    }
}