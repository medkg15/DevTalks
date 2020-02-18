using System;
using System.Collections.Generic;

namespace DesignPatterns._02_Mediator
{
    /// <summary>
    /// Represents a magazine subscription & delivery agent.  Makes magazine subscriptions available to subscribers and handles delivery to current subscribers.
    /// </summary>
    public class SubscriptionAgent
    {
        private readonly IDictionary<string, MagazinePublisher> _publishers = new Dictionary<string, MagazinePublisher>();
        private readonly IDictionary<string, HashSet<MagazineSubscriber>> _subscribers = new Dictionary<string, HashSet<MagazineSubscriber>>();

        /// <summary>
        /// Delivers the magazine to all subscribed subscribers.
        /// </summary>
        /// <param name="magazine"></param>
        public void Deliver(Magazine magazine)
        {
            if (!_subscribers.ContainsKey(magazine.Title))
            {
                Console.WriteLine($"There are no subscribers for {magazine.Title}.");
            }

            var count = 0;
            foreach (var subscriber in _subscribers[magazine.Title])
            {
                subscriber.Receive(magazine);
                count++;
            }

            Console.WriteLine($"Delivered {magazine.Title} {magazine.Edition} to {count} subscribers.");
        }

        /// <summary>
        /// Registers the publisher of the given magazine, allowing subscribers to subscribe to it.
        /// </summary>
        /// <param name="magazineName"></param>
        /// <param name="publisher"></param>
        public void Register(string magazineName, MagazinePublisher publisher)
        {
            if (!_publishers.ContainsKey(magazineName))
            {
                _publishers.Add(magazineName, publisher);
            }

            Console.WriteLine($"{publisher.Name} is publishing {magazineName}.");
        }

        /// <summary>
        /// Subscribe the subscriber to the given magazine.
        /// </summary>
        /// <param name="magazineName"></param>
        /// <param name="subscriber"></param>
        public void Subscribe(string magazineName, MagazineSubscriber subscriber)
        {
            if (!_subscribers.ContainsKey(magazineName))
            {
                _subscribers[magazineName] = new HashSet<MagazineSubscriber>();
            }

            if (_subscribers[magazineName].Contains(subscriber))
            {
                Console.WriteLine($"{subscriber.Name} cannot subscribe to {magazineName} more than once.");
            }
            else
            {
                _subscribers[magazineName].Add(subscriber);

                Console.WriteLine($"{subscriber.Name} has been subscribed to {magazineName}.");
            }
        }

        /// <summary>
        /// Remove the subscriber for the given magazine.
        /// </summary>
        /// <param name="magazineName"></param>
        /// <param name="subscriber"></param>
        public void Unsubscribe(string magazineName, MagazineSubscriber subscriber)
        {
            if (!_subscribers.ContainsKey(magazineName) || !_subscribers[magazineName].Contains(subscriber))
            {
                Console.WriteLine($"{subscriber.Name} was not subscribed to {magazineName}.");
            }

            _subscribers[magazineName].Remove(subscriber);

            Console.WriteLine($"{subscriber.Name} is no longer subscribed to {magazineName}.");
        }

        /// <summary>
        /// The subscriptions that are currently available.
        /// </summary>
        public IEnumerable<string> AvailableSubscriptions => _publishers.Keys;
    }
}
