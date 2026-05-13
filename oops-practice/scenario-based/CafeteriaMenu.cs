using System;
class CafeteriaMenu
{
    static void DisplayMenu(string[] items)
    {
        Console.WriteLine("==================== CAFETERIA MENU ==========================");
        for(int i = 0; i < items.Length; i++)
        {
            Console.WriteLine(i+" : "+items[i]);
        }
    }

    static string GetItemByIndex(string[] items, int index)
    {
        if(index >= 0 && index < items.Length)
        {
            return items[index];
        }
        else
        {
            return "Invalid Access";
        }
    }
    static void Main(string[] args)
    {
        string[] menuItems =
        {
            "Pizza",
            "Burger",
            "Sandwich",
            "Pasta",
            "French Fries",
            "Cold Coffee",
            "Tea",
            "Juice",
            "Ice-Cream",
            "Patis"  
        };

        int[] quantity = new int[menuItems.Length];
        int choice;


        do
        {
            Console.WriteLine("================ Cafeteria System ===================");
            Console.WriteLine("1. Display Menu");
            Console.WriteLine("2. Order Item");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter Your Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayMenu(menuItems);
                    break;

                case 2:
                    DisplayMenu(menuItems);

                    Console.WriteLine("=========== SELECT A NUMBER TO CHOOSE YOUR FOOD ITEM =========");
                    int index = Convert.ToInt32(Console.ReadLine());

                    string SelectedItems = GetItemByIndex(menuItems,index);

                    if(SelectedItems != null)
                    {
                        quantity[index]++;
                        Console.WriteLine(SelectedItems+" added! Quantity: "+quantity[index]);
                    }

                    else
                    {
                        Console.WriteLine("Invalid Item");
                    }
                    break;
                
                case 3:
                    Console.WriteLine("=============== Order Summary ===================");
                    for(int i = 0; i < menuItems.Length; i++)
                    {
                        if(quantity[i] > 0)
                        {
                            Console.WriteLine(menuItems[i] +" x " + quantity[i]);
                        }
                    }
                    Console.WriteLine("Thanku you! Visit Again");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }while(choice != 3);
    }
}