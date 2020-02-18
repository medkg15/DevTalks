using System;

namespace DesignPatterns._02_Mediator
{
    /// <summary>
    /// Represents a company that publishes magazines.
    /// </summary>
    public class MagazinePublisher
    {
        private readonly SubscriptionAgent _agent;

        public MagazinePublisher(SubscriptionAgent agent, string name)
        {
            _agent = agent;
            Name = name;
            _agent.Register(name, this);
        }

        public string Name { get; set; }

        public void Publish(Magazine magazine)
        {
            Console.WriteLine($"{Name} published {magazine.Title} {magazine.Edition}.");

            _agent.Deliver(magazine);
        }
    }
}
