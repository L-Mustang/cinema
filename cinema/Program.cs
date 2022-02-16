namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie("Shrek");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddHours(11), 10);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 5, 42);
            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket);
            
            OrderReporter observer = new OrderReporter();
            observer.Subscribe(order.orderMonitor);


            order.submit();
            order.provision();
            order.cancel();

            observer.Unsubscribe();
        }
    }
}