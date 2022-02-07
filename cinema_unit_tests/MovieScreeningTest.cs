using Microsoft.VisualStudio.TestTools.UnitTesting;
using cinema;
using System;

namespace cinema_unit_tests
{
    [TestClass]
    public class MovieScreeningTest
    {
        [TestMethod]
        public void TestMovieScreening()
        {
            //Arrange
            Movie movie = new Movie("Shrek");

            //Act
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.UtcNow, 8);

            //Assert
            Assert.IsNotNull(movieScreening);
        }
    }
}