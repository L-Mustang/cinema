using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderStateNotSubmitted : OrderState
    {
        private Order order;

        public OrderStateNotSubmitted(Order order)
        {
            this.order = order;
        }

        public void cancel()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void pay()
        {
            throw new NotImplementedException();
        }

        public void provision()
        {
            throw new NotImplementedException();
        }

        public void submit()
        {
            order.setState(order.getSubmittedState());
        }
    }
}
