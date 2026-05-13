using System;
class FindTheMostFrequentCharacter
{
    static void Main(string[] args)
    {
        string str = "success";
        int Maxcount = 0;
        char MostFrequent = str[0];

        for(int i = 0; i < str.Length; i++)
        {
            int count=0;
            for(int j = 0; j < str.Length; j++)
            {
                if(str[i] == str[j])
                {
                    count++;
                }
                if(count > Maxcount)
                {
                    Maxcount = count;
                    MostFrequent = str[i];
                }
            }
        }
        Console.WriteLine("Most Frequent Character: '"+MostFrequent+"'");
    }
}