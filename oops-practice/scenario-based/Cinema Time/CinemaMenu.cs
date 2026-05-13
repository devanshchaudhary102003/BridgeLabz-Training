using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTime
{
    internal class CinemaMenu
    {
        CinemaUtilityImpl CinemaUtility = new CinemaUtilityImpl();
        public void Menu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n🎬 CinemaTime – Movie Schedule Manager");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Search Movie");
                Console.WriteLine("3. Display All Movies");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Movie Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Show Time: ");
                        string time = Console.ReadLine();

                        CinemaUtility.AddMovie(title, time);
                        break;

                    case 2:
                        Console.Write("Enter keyword to search: ");
                        string keyword = Console.ReadLine();
                        CinemaUtility.SearchMovie(keyword);
                        break;

                    case 3:
                        CinemaUtility.DisplayAllMovies();
                        break;

                    case 4:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 4);
        }
    }
}
