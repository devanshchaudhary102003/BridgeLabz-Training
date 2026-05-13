using System;

namespace AccessModifier
{
    class Parent
    {
        public int publicVar = 10;
        private int privateVar = 20;
        protected int protectedVar = 30;
        internal int internalVar = 40;
        protected internal int protectedInternalVar = 50;

        public void ShowParentData()
        {
            Console.WriteLine("Inside Parent Class:");
            Console.WriteLine(publicVar);
            Console.WriteLine(privateVar);
            Console.WriteLine(protectedVar);
            Console.WriteLine(internalVar);
            Console.WriteLine(protectedInternalVar);
        }
    }

    class Child : Parent
    {
        public void ShowChildData()
        {
            Console.WriteLine("\nInside Child Class:");
            Console.WriteLine(publicVar);
            Console.WriteLine(protectedVar);
            Console.WriteLine(internalVar);
            Console.WriteLine(protectedInternalVar);
        }
    }

    class Program
    {
        static void Main()
        {
            Parent p = new Parent();
            p.ShowParentData();

            Child c = new Child();
            c.ShowChildData();
        }
    }
}
