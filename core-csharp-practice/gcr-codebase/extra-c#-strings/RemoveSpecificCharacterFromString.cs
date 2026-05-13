using System;
class RemoveSpecificCharacterFromString
{
    static void Main(string[] args)
    {
        String str = "Hello World";
        char CharacterRemove = 'l';
        string result = "";

        foreach(char c in str)
        {
            if(c != CharacterRemove)
            {
                result += c;
            }
        }
        Console.WriteLine("Modified String:"+result);
    }
}