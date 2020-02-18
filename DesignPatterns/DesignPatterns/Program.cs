using System;
using System.IO;

namespace DesignPatterns._02_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var agent = new SubscriptionAgent();

            var publishers = new[]
            {
                new MagazinePublisher(agent, "Home Cooking"),
                new MagazinePublisher(agent, "Sports Illustrated Inc"),
            };

            var subscribers = new[]
            {
                new MagazineSubscriber(agent, "John Smith"),
                new MagazineSubscriber(agent, "Sally Smith"),
            };

            Console.WriteLine("The following magazine subscriptions are available:");

            foreach (var magazine in agent.AvailableSubscriptions)
            {
                Console.WriteLine("- " + magazine);
            }

            subscribers[0].Subscribe("Holiday Cooking");
            subscribers[1].Subscribe("Holiday Cooking");
            subscribers[1].Subscribe("Sports Illustrated");

            // John and Sally receive the magazine
            publishers[0].Publish(new Magazine
            {
                Title = "Holiday Cooking",
                Edition = "Winter 2020",
                Content = new MemoryStream()
            });

            // Only Sally receives the magazine
            publishers[1].Publish(new Magazine
            {
                Title = "Sports Illustrated",
                Edition = "Spring 2020",
                Content = new MemoryStream()
            });
        }
    }
}
