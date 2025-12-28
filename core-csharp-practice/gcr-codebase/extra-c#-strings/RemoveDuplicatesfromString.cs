using System;
class RemoveDuplicatesfromString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        string result = "";
        
        for(int i = 0; i < str.Length; i++)
        {
            bool IsDuplicate = false;
            for(int j = i + 1; j < str.Length; j++)
            {
                if(str[i] == str[j])
                {
                    IsDuplicate = true;
                    break;
                }
            }
            if (!IsDuplicate)
            {
                result += str[i];
            }
        }
        Console.WriteLine("String after removing duplicates:"+result);
    }
}