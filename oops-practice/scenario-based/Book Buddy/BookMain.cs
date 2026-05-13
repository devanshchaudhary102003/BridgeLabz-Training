using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddy
{
    internal class BookMain
    {
        static void Main(string[] args)
        {
            BookMenu menu = new BookMenu();
            menu.Menu();
        }
    }
}
