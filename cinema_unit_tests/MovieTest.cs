using Microsoft.VisualStudio.TestTools.UnitTesting;
using cinema;

namespace cinema_unit_tests
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void TestMovie()
        {
            //Arrange
            Movie movie = new Movie("Shrek");

            //Act

            //Assert
            Assert.IsNotNull(movie);
        }
    }
}