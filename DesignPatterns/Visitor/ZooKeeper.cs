using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class ZooKeeper : IAnimalVisitor
    {
        public void Visit(Bear bear)
        {
            Console.WriteLine($"Brought some berries for the {bear.Breed} bear.");
        }

        public void Visit(Lizard lizard)
        {
            Console.WriteLine($"Some insects for the {lizard.Color} lizard.");
        }

        public void Visit(Fish fish)
        {
            Console.WriteLine("Fish food for the fish!");
        }
    }
}
