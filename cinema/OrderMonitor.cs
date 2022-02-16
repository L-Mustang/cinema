using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderMonitor : IObservable<Order>
    {
        public List<IObserver<Order>> observers;

        public OrderMonitor()
        {
            observers = new List<IObserver<Order>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Order>> _observers;
            private IObserver<Order> _observer;

            public Unsubscriber(List<IObserver<Order>> observers, IObserver<Order> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
        
        public void orderStateChanged(Order order)
        {
            foreach (IObserver<Order> observer in observers)
                observer.OnNext(order);
        }


        public void orderRemoved()
        {
            foreach (IObserver<Order> observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }
    }
}
