using System;
class AtmDispenserLogic
{
    static void Main(string[] args)
    {
        int[] Notes = {500,200,100,50,20,10,5,2,1};

        Console.WriteLine("Enter The Amount To WithDraw: ");
        int amount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n----- Scenario A: All Notes -------");
        Dispense(amount,Notes);

        Console.WriteLine("\n----- Scenario B: All Notes Without 500 -------");
        int[] NoteWithout500 = {200,100,50,20,10,5,2,1};
        Dispense(amount,NoteWithout500);

        Console.WriteLine("\n----- Scenario C: FallBack Combo -------");
        int[] LimitedNotes = {5,2};
        DispenseWithFallback(amount,LimitedNotes);
    }

    //Method to dispense minimum notes
    static void Dispense(int amount,int[] Notes)
    {
        int[] NoteCount = new int[Notes.Length];
        int remaining = amount;

        for(int i = 0; i < Notes.Length; i++)
        {
            if(remaining >= Notes[i])
            {
                NoteCount[i] = remaining/Notes[i];
                remaining = remaining - (NoteCount[i] * Notes[i]);
            }
        }

        if(remaining == 0)
        {
            Console.WriteLine("Amount "+amount+" can be dispensed");
            int TotalNotes= 0;

            for(int i = 0; i < Notes.Length; i++)
            {
                if(NoteCount[i] > 0)
                {
                    Console.WriteLine(Notes[i]+" x "+NoteCount[i]);
                    TotalNotes = TotalNotes + NoteCount[i];
                }
            }
            Console.WriteLine("Total Notes: "+TotalNotes);
        }
        else
        {
            Console.WriteLine("Exact amount cannot be dispensed");
        }
    }
    
    static void DispenseWithFallback(int amount,int[] Notes)
    {
        int remaining = amount;
        int[] NotesCount = new int[Notes.Length];

        for(int i = 0; i < Notes.Length; i++)
        {
            if(remaining >= Notes[i])
            {
                NotesCount[i] = remaining/Notes[i];
                remaining = remaining - (NotesCount[i] * Notes[i]);
            }
        }
        int DispensedAmount = amount - remaining;

        Console.WriteLine("Request Amount: "+amount);
        Console.WriteLine("Dispensed Amount: "+DispensedAmount);
        Console.WriteLine("Notes Given");

        for(int i = 0; i < Notes.Length; i++)
        {
            if(NotesCount[i] > 0)
            {
                Console.WriteLine(Notes[i]+" x "+NotesCount[i]);
            }
        }
        if(remaining > 0)
        {
            Console.WriteLine("Remaining Amount is not dispensible: "+remaining);
        }
    }
}