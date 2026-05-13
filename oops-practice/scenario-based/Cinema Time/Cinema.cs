using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTime
{
    internal class Cinema
    {
        private string Title;
        private string Time;

        public string title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }

        public string time
        {
            get
            {
                return Time;
            }
            set
            {
                Time = value;
            }
        }

        public override string ToString()
        {
            return "Movie Title: " + title + " Movie Timing: " + time;
        }
    }
}
