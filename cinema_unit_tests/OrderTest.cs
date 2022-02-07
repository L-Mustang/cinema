using Microsoft.VisualStudio.TestTools.UnitTesting;
using cinema;
using System;

namespace cinema_unit_tests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestOrderConstructor()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.UtcNow, 8);
            MovieTicket movieTicket = new MovieTicket(movieScreening, true, 5, 42);

            //Act
            Order order = new Order(1, true);

            //Assert
            Assert.IsNotNull(order);
        }
    }
}