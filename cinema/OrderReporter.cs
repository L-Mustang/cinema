using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class OrderReporter : IObserver<Order>
    {
        private IDisposable? unsubscriber;

        public virtual void Subscribe(IObservable<Order> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber?.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("OrderState listener disconnected.");
        }

        public virtual void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(Order order)
        {
            string message = $"Your order has been set to {order.state}";
            MessageAdapter messageAdapterFacebook = new MessageAdapterFacebook();
            MessageAdapter messageAdapterIMessage = new MessageAdapterIMessage();
            MessageAdapter messageAdapterWhatsapp = new MessageAdapterWhatsApp();
            messageAdapterFacebook.SendMessage(message);
            messageAdapterIMessage.SendMessage(message);
            messageAdapterWhatsapp.SendMessage(message);
        }
    }
}
