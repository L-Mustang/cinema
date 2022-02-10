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
        private OrderState stateNotSubmitted;
        private OrderState stateSubmitted;
        private OrderState stateProcessed;
        private OrderState stateProvisional;

        private OrderState state;

        private int orderNr { get; set; }
        private bool isStudentOrder { get; set; }
        public List<MovieTicket> tickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.stateNotSubmitted = new OrderStateNotSubmitted(this);
            this.stateSubmitted = new OrderStateSubmitted(this);
            this.stateProcessed = new OrderStateProcessed(this);
            this.stateProvisional = new OrderStateProvisional(this);
            this.state = stateNotSubmitted;

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
                try
                {
                    for (int i = 1; i < tickets.Count; i += 2)
                    {
                        prices[i] = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);          
                }
            }
            //2
            else
            {
                if (this.tickets.Count >= 6)
                {
                    for(int i = 0;i < prices.Count; i++)
                    {
                        prices[i] *= 0.9;
                    }
                }
            }

            prices.ForEach(i =>
            {
                totalPrice += i;
            });
         
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

        public void setState(OrderState state)
        {
            this.state = state;
        }

        public OrderState getNotSubmittedState()
        {
            return this.stateNotSubmitted;
        }

        public OrderState getSubmittedState()
        {
            return this.stateSubmitted;
        }

        public OrderState getProcessedState()
        {
            return this.stateProcessed;
        }

        public OrderState getProvisionalState()
        {
            return this.stateProvisional;
        }


    }
}