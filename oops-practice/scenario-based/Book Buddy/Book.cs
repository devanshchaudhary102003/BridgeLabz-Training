using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddy
{
    internal class Book
    {
        private string Title;
        private string Author;


        public string title
        {
            get{
                return Title;
            }
            set{
                Title = value;
            }
        }

        public string author
        {
            get
            {
                return Author;
            }
            set
            {
                Author = value;
            }
        }

        public override string ToString()
        {
            return "Title Name: " + title + " Author Name: " + author;
        }
    }
}
