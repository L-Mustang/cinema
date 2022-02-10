using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderStateProcessed : OrderState
    {
        private Order order;

        public OrderStateProcessed(Order order)
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
            throw new NotImplementedException();
        }
    }
}
