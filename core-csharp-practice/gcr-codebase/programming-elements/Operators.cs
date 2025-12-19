using System;
class Animal{}
class Dog:Animal{}
class Operators
{
	static void Main(string[] args)
	{
		int a = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
		
		//Arithmetic Operators
		Console.WriteLine("Addition:"+(a+b));
		Console.WriteLine("Subtraction:"+(a-b));
		Console.WriteLine("Multiplication:"+(a*b));
		Console.WriteLine("Division:"+(a/b));
		Console.WriteLine("Modulus:"+(a%b));

        //Relational Operators
        Console.WriteLine("a==b:"+(a==b));
        Console.WriteLine("a!=b:"+(a!=b));
        Console.WriteLine("a>b:"+(a>b));
        Console.WriteLine("a<b:"+(a<b));
        Console.WriteLine("a>=b:"+(a>=b));
        Console.WriteLine("a<=b:"+(a<=b));

        //Logical Oerators
        bool c = true;
        bool d = false;

        Console.WriteLine("c&&d:"+(c&&d));
        Console.WriteLine("c||d:"+(c||d));
        Console.WriteLine("!c:"+(!c));
        Console.WriteLine("!d:"+(!d));

        //Assignment Operators
        //a+=b => a=a+b
        Console.WriteLine("a+=b:"+(a+=b));
        //a-=b => a=a-b
        Console.WriteLine("a-=b:"+(a-=b));
        //a*=b => a=a*b
        Console.WriteLine("a*=b:"+(a*=b));
        //a/=b => a=a/b
        Console.WriteLine("a/=b:"+(a/=b));
        //a%=b => a=a%b
        Console.WriteLine("a%=b:"+(a%=b));

        //Unary Operators
        Console.WriteLine("a:"+a);
        Console.WriteLine("++a:"+ ++a);
        Console.WriteLine("a++:"+ a++);
        Console.WriteLine("a:"+a);
        Console.WriteLine("b:"+b);
        Console.WriteLine("--b:"+ --b);
        Console.WriteLine("b--:"+ b--);
        Console.WriteLine("b:"+b);

        //Ternary Operator
        int max = (a>b) ? a : b;

        Console.WriteLine("max:"+max);

        //is Operator
        Animal D = new Dog();

        Console.WriteLine("D is Animal:"+(D is Animal));
        Console.WriteLine("D is Dog:"+(D is Dog));
        Console.WriteLine("D is String:"+(D is string));
	}
}