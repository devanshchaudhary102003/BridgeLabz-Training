using System;

class LegacyAPI
{
    [Obsolete("OldFeature is obsolete. Use NewFeature instead.")]
    public void OldFeature()
    {
        Console.WriteLine("This is the OLD feature");
    }

    public void NewFeature()
    {
        Console.WriteLine("This is the NEW feature");
    }
}
class Attribute
{
    static void Main(string[] args)
    {
        LegacyAPI legacyAPI = new LegacyAPI();
        legacyAPI.OldFeature();
        legacyAPI.NewFeature();
    }
}