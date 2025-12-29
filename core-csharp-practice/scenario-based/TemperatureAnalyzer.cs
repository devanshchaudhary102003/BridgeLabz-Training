using System;
class TemperatureAnalyzer
{
    static void Main(string[] args)
    {
        float[,] temperature = new float[7,24];

        for(int day = 0; day < 7; day++)
        {
            Console.WriteLine("Enter Temperature for Day "+(day+1)+":");
            for(int hour = 0; hour < 24; hour++)
            {
                temperature[day,hour] = float.Parse(Console.ReadLine());
            }
        }
        AnalyzTemperature(temperature);
    }

    static void AnalyzTemperature(float[,] temp)
    {
        int HotDay = 0;
        int ColdDay = 0;

        float maxTemp = float.MinValue;
        float minTemp = float.MaxValue;

        for(int day = 0; day < 7; day++)
        {
            float dailySum = 0;
            for(int hour = 0; hour < 24; hour++)
            {
                float CurrentTemp = temp[day,hour];
                dailySum += CurrentTemp;

                if(CurrentTemp > maxTemp)
                {
                    maxTemp = CurrentTemp;
                    HotDay = day;
                }
                if(CurrentTemp < minTemp)
                {
                    minTemp = CurrentTemp;
                    ColdDay = day;
                }
            }
            float average = dailySum/24;
            Console.WriteLine("Average temperature of Day "+(day+1)+": "+average);
        }
        Console.WriteLine("Hottest Day:"+(HotDay+1)+" Temp "+maxTemp);
        Console.WriteLine("Coldest Day:"+(ColdDay+1)+" Temp "+minTemp);
    }
}