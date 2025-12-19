using System;
class VolumeOfEarth
{
    static void Main(string[] args)
    {
        int r = 6378;
        double vol = (4/3)*Math.PI*Math.Pow(r,3);
        double volu = vol * 1.6;
        
        Console.WriteLine("The volume of earth in cubic kilometers is:"+vol+"and cubic miles is:"+volu);
    }
}