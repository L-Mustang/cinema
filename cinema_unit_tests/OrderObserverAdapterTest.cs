using Microsoft.VisualStudio.TestTools.UnitTesting;
using cinema;
using System;
using System.IO;

namespace cinema_unit_tests
{
    [TestClass]
    public class OrderObserverAdapterTest
    {
        [TestMethod]
        public void TestOrderState_Submitted_Provisional_Processed()
        {
            using (StringWriter sw = new StringWriter())
            {
                //Arrange
                Console.SetOut(sw);
                string expected = "{0}: Your order has been set to {1}";
                Movie movie = new Movie("Shrek");
                MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddHours(23), 10);
                MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
                Order order = new Order(1, false);
                order.addSeatReservation(movieTicket);

                OrderReporter observer = new OrderReporter();
                observer.Subscribe(order.orderMonitor);

                //Act & Assert
                order.submit();

                StringAssert.Contains(sw.ToString(), string.Format(expected, "Facebook", "submitted"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "Whatsaap", "submitted"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "IMessage", "submitted"));

                order.provision();

                StringAssert.Contains(sw.ToString(), string.Format(expected, "Facebook", "provisional"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "Whatsaap", "provisional"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "IMessage", "provisional"));

                order.pay();

                StringAssert.Contains(sw.ToString(), string.Format(expected, "Facebook", "processed"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "Whatsaap", "processed"));
                StringAssert.Contains(sw.ToString(), string.Format(expected, "IMessage", "processed"));
            }
        }
    }
}
