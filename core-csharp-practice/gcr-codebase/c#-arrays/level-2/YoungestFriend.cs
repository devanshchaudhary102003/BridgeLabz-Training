using System;
class YoungestFriend
{
    static void Main(string[] args)
    {
        string[] names = {"Amar","Akbar","Anthony"};
        int[] age = new int[3];
        double[] height = new double[3];

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter Age:");
            age[i] = Convert.ToInt32(Console.ReadLine());
        }

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter Height:");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        int YoungestIdx = 0;
        int TallestIdx = 0;
        for(int i = 1; i < 3; i++)
        {
            if(age[i] < age[YoungestIdx])
            {
                YoungestIdx = i;
            }
            if(height[i] > height[TallestIdx])
            {
                TallestIdx = i;
            }
        }

        Console.WriteLine("Youngest Friend :"+names[YoungestIdx]+"Age :"+age[YoungestIdx]);
        Console.WriteLine("Tallest Friend :"+names[TallestIdx]+"Height :"+height[TallestIdx]);
    }
}