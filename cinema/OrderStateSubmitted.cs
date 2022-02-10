using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderStateSubmitted : OrderState
    {
        private Order order;

        public OrderStateSubmitted(Order order)
        {
            this.order = order;
        }

        public void cancel()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            order.setState(order.getNotSubmittedState());
        }

        public void pay()
        {
            order.setState(order.getProcessedState());
        }

        public void provision()
        {
            //if( timeDiff <= 24){
            //sendNotification();
            //order.setState(order.getProvisionalState());
            //}

            DateTime timeOfOrder = DateTime.Now;
            DateTime timeOfMovieScreening = order.tickets[0].movieScreening.dateAndTime;
            double timeDiff = timeOfMovieScreening.Subtract(timeOfOrder).TotalHours;
            
            if (timeDiff <= 24.0)
            {
                notify();
                order.setState(order.getProvisionalState());                
            }
        }

        public void submit()
        {
            throw new NotImplementedException();
        }

        public void notify()
        {
            Console.WriteLine("Notification of order to be paid")
        }
    }
}
