/*tory 2: Custom Furniture Manufacturing
Context: A carpenter cuts wooden rods for furniture with pricing based on size.
Scenario A: Determine best cut to maximize earnings for 12ft rod.
Scenario B: If customer adds a fixed waste constraint, modify logic.
Scenario C: Suggest cuts for maximizing both revenue and minimal waste.*/

using System;
//=====================Interface====================
interface IRodCutStrategy
{
    void Calculate(int rodLength);
}

//=======================Encapsulation===============
class WoodenRod
{
    private int Length;

    public void SetLength(int length)
    {
        Length = length;
    }

    public int GetLength()
    {
        return Length;
    }
}

//========================Scenario=======================
// Maximize Revenue
class MaxRevenueCut : IRodCutStrategy
{
    int[] lengths = {1,2,3,4,5,6};
    int[] prices = {2,5,7,8,10,13};

    public void Calculate(int rodLength)
    {
        int maxRevenue = 0;
        
        for(int i = 0; i < lengths.Length; i++)
        {
            int pieces = rodLength / lengths[i];
            int revenue = pieces * prices[i];

            if(revenue > maxRevenue)
            {
                maxRevenue = revenue;
            }
        }
        Console.WriteLine("Scenario A - Max Revenue: "+maxRevenue);
    }
}

//======================Scenario B======================
// Fixed Waste Constraint
class WasteLimitedCut : IRodCutStrategy
{
    int[] lengths = {1,2,3,4,5,6};
    int[] prices = {2,5,7,8,10,13};
    int maxWaste = 2;

    public void Calculate(int rodLength)
    {
        int bestRevenue = 0;

        for(int i = 0; i < lengths.Length; i++)
        {
            int usedLength = (rodLength/lengths[i]) * lengths[i];
            int waste = rodLength - usedLength;

            if(waste <= maxWaste)
            {
                int revenue = (usedLength / lengths[i]) * prices[i];

                if(revenue > bestRevenue)
                {
                    bestRevenue = revenue;
                }
            }
        }
        Console.WriteLine("Scenario B - Revenue With Waste : "+maxWaste+": Best Revenue : "+bestRevenue);
    }
}

//==========================Scenario C =======================
// Max Revenue + Minimum Waste

class BestBalancedCut : IRodCutStrategy
{
    int[] lengths = {1,2,3,4,5,6};
    int[] prices = {2,5,7,8,10,13};

    public void Calculate(int rodLength)
    {
        int bestRevenue = 0;
        int minWaste = rodLength;

        for(int i = 0; i < lengths.Length; i++)
        {
            int pieces = rodLength / lengths[i];
            int usedLength = pieces * lengths[i];
            int waste = rodLength - usedLength;
            int revenue = pieces * prices[i];

            if(revenue > bestRevenue || revenue == bestRevenue && waste < minWaste)
            {
                bestRevenue = revenue;
                minWaste = waste;
            }
        }
        Console.WriteLine("Scenario C - Best Revenue: " + bestRevenue + ", Waste: " + minWaste);
    }
}
class CustomFurnitureManufacturing
{
    static void Main(string[] args)
    {
        WoodenRod rod = new WoodenRod();
        rod.SetLength(12);

        IRodCutStrategy strategy;

        strategy = new MaxRevenueCut();
        strategy.Calculate(rod.GetLength());

        strategy = new WasteLimitedCut();
        strategy.Calculate(rod.GetLength());

        strategy = new BestBalancedCut();
        strategy.Calculate(rod.GetLength());
    }
}
