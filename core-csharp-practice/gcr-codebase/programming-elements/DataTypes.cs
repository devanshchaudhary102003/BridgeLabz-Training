using System;
class DataTypes
{
    static void Main(string[] args)
    {
        //8-bit or 1-byte
        byte b = 4;
        Console.WriteLine("b in byte:"+b);

        //16-bit or 2-byte
        short s = 6;
        Console.WriteLine("s in short:"+s);

        //32-bit or 4-byte
        int i = 5;
        Console.WriteLine("i in int:"+i);

        //64-Bit or 8-byte 
        long l = 7;
        Console.WriteLine("l in long:"+l);

        //32-bit or 4-byte
        float f = 8;
        Console.WriteLine("f in float:"+f);

        //64-bit or 8-byte
        double d = 9;
        Console.WriteLine("d in double:"+d);

        //16-bit or 2-byte
        char c = 3;
        Console.WriteLine("c in char:"+c);

        //1-bit
        bool bo = true;
        Console.WriteLine("bo in boolean:"+bo);

        //byte to int
        int a = b;
        Console.WriteLine("Implicit Type Casting (byte to int):"+a);

        //int to float
        float e = i;
        Console.WriteLine("Implicit Type Casting (int to float):"+e.ToString("0.0"));

        
    }
}