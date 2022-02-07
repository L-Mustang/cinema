using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class Movie
    {
        private string title { get; set; }

        public Movie(string title)
        {
            this.title = title;
        }
        public void addScreening(MovieScreening screening)
        {
            screening.movie = this;
            return;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }   
}
