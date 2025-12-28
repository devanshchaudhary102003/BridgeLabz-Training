using System;
class CountVowelsAndConsonants
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        int CountVowels = 0;
        int CountConsonants = 0;
        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
            {
                CountVowels++;
            }
            else
            {
                CountConsonants++;
            }
        }
        Console.WriteLine("Vowels are :"+CountVowels);
        Console.WriteLine("Consonants are :"+CountConsonants);
    }
}