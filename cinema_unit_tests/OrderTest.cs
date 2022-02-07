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

        [TestMethod]
        public void TestCalculatePrice_NoPremium_NoStudent_NoWeekday_LessThan6Tickets()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 6), 10); 

            //5 non-premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, false, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, false, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, false, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, false, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, false, 9, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = movieScreening.getPricePerSeat()* 5;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_NoPremium_NoStudent_NoWeekday_MoreThan5Tickets()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 6), 10);

            //6 premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, false, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, false, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, false, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, false, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, false, 9, 42);
            MovieTicket movieTicket6 = new MovieTicket(movieScreening, false, 10, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);
            order.addSeatReservation(movieTicket6);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = movieScreening.getPricePerSeat() * 6.0 * 0.9;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_NoPremium_NoStudent_Weekday()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a week day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 7), 10);

            //5 non-premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, false, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, false, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, false, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, false, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, false, 9, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = movieScreening.getPricePerSeat() * 3;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_Premium_NoStudent_NoWeekday_LessThan6Tickets()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 6), 10);

            //5 premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, true, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, true, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, true, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, true, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, true, 9, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = (movieScreening.getPricePerSeat() + 3) * 5;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_Premium_NoStudent_NoWeekday_MoreThan5Tickets()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 6), 10);

            //6 premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, true, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, true, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, true, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, true, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, true, 9, 42);
            MovieTicket movieTicket6 = new MovieTicket(movieScreening, true, 10, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);
            order.addSeatReservation(movieTicket6);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = (movieScreening.getPricePerSeat() + 3) * 6 * 0.9;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_Premium_NoStudent_Weekday()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 7), 10);

            //5 premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, true, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, true, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, true, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, true, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, true, 9, 42);

            //Non-student order
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = (movieScreening.getPricePerSeat() + 3) * 3;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void TestCalculatePrice_Premium_Student()
        {
            //Arrange
            Movie movie = new Movie("Shrek");
            //Price of 10 euro per ticket on a weekend day
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 6), 10);

            //5 premium tickets
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, true, 5, 42);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, true, 6, 42);
            MovieTicket movieTicket3 = new MovieTicket(movieScreening, true, 7, 42);
            MovieTicket movieTicket4 = new MovieTicket(movieScreening, true, 8, 42);
            MovieTicket movieTicket5 = new MovieTicket(movieScreening, true, 9, 42);

            //student order
            Order order = new Order(1, true);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            order.addSeatReservation(movieTicket3);
            order.addSeatReservation(movieTicket4);
            order.addSeatReservation(movieTicket5);

            //Act
            double price = order.calculatePrice();
            double expectedPrice = (movieScreening.getPricePerSeat() + 2) * 3;

            //Assert
            Assert.AreEqual(expectedPrice, price);
        }
    }
}