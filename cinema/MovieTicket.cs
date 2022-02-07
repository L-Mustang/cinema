using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class MovieTicket
    {
        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private bool isPremium { get; set; }
        public MovieScreening movieScreening { get; set; }

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            this.movieScreening = movieScreening;
            this.isPremium = isPremiumReservation;
            this.rowNr = seatRow;
            this.seatNr = seatNr;
        }

        public bool isPremiumTicker()
        {
            return isPremium;
        }

        public double getPrice()
        {
            return this.movieScreening.getPricePerSeat();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
