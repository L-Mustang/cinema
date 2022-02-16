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
        public void TestOrderState_Submitted_Processed()
        {
            using (StringWriter sw = new StringWriter())
            {
                //Arrange
                Console.SetOut(sw);
                string expected = $"{0}: Your order has been set to {1}";

                Movie movie = new Movie("Shrek");
                MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddDays(2), 10);
                MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
                Order order = new Order(1, false);
                order.addSeatReservation(movieTicket);

                //Act & Assert
                order.submit();
                Assert.AreEqual<string>(String.Format(expected, "Facebook", "submitted"), sw.ToString());
                Assert.AreEqual<string>(String.Format(expected, "Whatsaap", "submitted"), sw.ToString());
                Assert.AreEqual<string>(String.Format(expected, "IMessage", "submitted"), sw.ToString());
                order.pay();
            }
        }

        [TestMethod]
        public void TestOrderState_Submitted_NotSubmitted()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddDays(2), 10);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket);

            //Act
            order.submit();
            order.edit();

            //Assert
            Assert.IsInstanceOfType(order.getState(), typeof(OrderStateNotSubmitted));
        }

        [TestMethod]
        public void TestOrderState_Submitted_Provisional_Processed()
        { //Arrange
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddHours(23), 10);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket);

            //Act
            order.submit();
            order.provision();
            order.pay();

            //Assert
            Assert.IsInstanceOfType(order.getState(), typeof(OrderStateProcessed));
        }

        [TestMethod]
        public void TestOrderState_Submitted_Provisional_NotSubmitted()
        { //Arrange
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddHours(11), 10);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket);

            //Act
            order.submit();
            order.provision();
            order.cancel();

            //Assert
            Assert.IsInstanceOfType(order.getState(), typeof(OrderStateNotSubmitted));
        }
    }
}
