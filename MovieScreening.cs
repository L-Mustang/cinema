using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class MovieScreening
    {
        private DateTime dateAndTime { get; set; }
        private double pricePerSeat { get; set; }
        public Movie movie { get; set; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
            this.movie = movie;
        }

        public double getPricePerSeat()
        {
            return this.pricePerSeat;
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
