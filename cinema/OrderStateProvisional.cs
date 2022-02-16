using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderStateProvisional : OrderState
    {
        private Order order;

        public OrderStateProvisional(Order order)
        {
            this.order = order;
        }

        public void cancel()
        {
            //if( timeDiff <= 12){
            //sendNotification();
            //order.setState(order.getProvisionalState());
            //}

            DateTime timeOfOrder = DateTime.Now;
            DateTime timeOfMovieScreening = order.tickets[0].movieScreening.dateAndTime;
            double timeDiff = timeOfMovieScreening.Subtract(timeOfOrder).TotalHours;

            if (timeDiff <= 12.0)
            {
                order.setState(order.getNotSubmittedState());
            }
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void pay()
        {
            order.setState(order.getProcessedState());
        }

        public void provision()
        {
            throw new NotImplementedException();
        }

        public void submit()
        {
            throw new NotImplementedException();
        }
        public override string? ToString()
        {
            return "provisional";
        }
    }
}
