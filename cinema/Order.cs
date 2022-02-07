using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cinema
{
    public class Order
    {
        private int orderNr { get; set; }
        private bool isStudentOrder { get; set; }
        private List<MovieTicket> tickets;  

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.tickets = new List<MovieTicket>();
        }

        public int OrderNr()
        {
            return this.orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            this.tickets.Add(ticket);
        }

        public double calculatePrice()
        {
            DayOfWeek day = this.tickets[0].movieScreening.dateAndTime.DayOfWeek;
            double totalPrice = 0;
            List<double> prices = new List<double>();

            //3
            this.tickets.ForEach(i =>
            {
                if (i.isPremiumTicker())
                {
                    if (this.isStudentOrder)
                    {
                        prices.Add(i.getPrice() + 2);
                    }
                    else prices.Add(i.getPrice() + 3);
                }
                else prices.Add(i.getPrice());

            });


            //1
            if (this.isStudentOrder || day >= DayOfWeek.Monday && day <= DayOfWeek.Thursday)
            {
                for(int i=0; i<tickets.Count;i+=2)
                {
                    prices[i] = 0;
                }
            }

            prices.ForEach(i =>
            {
                totalPrice += i;
            });
            
            //2
            if(!this.isStudentOrder && day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                if (this.tickets.Count >= 6)
                {
                    totalPrice = totalPrice * 0.9;
                }
            }
         
            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            if(exportFormat == TicketExportFormat.PLAINTEXT)
            {
                Console.WriteLine(this);
            }
            else if(exportFormat == TicketExportFormat.JSON)
            {
                Console.WriteLine(JsonSerializer.Serialize(this));
            }
        }


    }
}