using System;

namespace DesignPatterns._02_Mediator
{
    /// <summary>
    /// Represents an individual who subscribes to one or more magazines.
    /// </summary>
    public class MagazineSubscriber
    {
        private readonly SubscriptionAgent _agent;
        public string Name { get; }

        public MagazineSubscriber(SubscriptionAgent agent, string name)
        {
            _agent = agent;
            Name = name;
        }

        public void Subscribe(string magazine)
        {
            Console.WriteLine($"{Name} wants to receive {magazine}.");

            _agent.Subscribe(magazine, this);
        }

        public void Receive(Magazine magazine)
        {
            Console.WriteLine($"{Name} received {magazine.Title} {magazine.Edition}.");
        }
    }
}
