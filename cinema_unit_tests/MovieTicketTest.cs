using Microsoft.VisualStudio.TestTools.UnitTesting;
using cinema;
using System;

namespace cinema_unit_tests
{
    [TestClass]
    public class MovieTicketTest
    {
        [TestMethod]
        public void TestMovieTicket()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.UtcNow, 8);

            //Act
            MovieTicket movieTicket = new MovieTicket(movieScreening, true, 5, 42);

            //Assert
            Assert.IsNotNull(movieTicket);
        }
    }
}