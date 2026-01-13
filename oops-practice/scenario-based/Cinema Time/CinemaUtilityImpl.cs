using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTime
{
    internal class CinemaUtilityImpl : ICinema
    {
        private Cinema[] movies = new Cinema[5];
        private int count = 0;

        public void AddMovie(string title, string time)
        {
            if(count == movies.Length)
            {
                Cinema[] newArray = new Cinema[movies.Length * 2];

                for(int i = 0; i < movies.Length; i++)
                {
                    newArray[i] = movies[i];
                }
                movies = newArray;
            }

            Cinema cinema = new Cinema();
            cinema.title = title;
            cinema.time = time;

            movies[count] = cinema;
            count++;

            Console.WriteLine("Movie Added Successfully.\n");
        }

        public void SearchMovie(string keyword)
        {
            bool found = false;

            for(int i = 0; i < count; i++)
            {
                if (movies[i].title.Contains(keyword))
                {
                    Console.WriteLine("Movie Title: " + movies[i].title+"Movie Time: " + movies[i].time);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Movie found with keyword: "+keyword);
            }
        }

        public void DisplayAllMovies()
        {
            if(count == 0)
            {
                Console.WriteLine("No Movie Availbale");
                return;
            }

            for(int i=0;i<count;i++)
            {
                Console.WriteLine("Movie Title: " + movies[i].title + "Movie Time: " + movies[i].time);
            }
        }
    }
}
