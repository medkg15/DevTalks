using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class ZooVisitor : IAnimalVisitor
    {
        public void Visit(Bear bear)
        {
            Console.WriteLine($"Looking at the {bear.Breed} bear through the fence.");
        }

        public void Visit(Lizard lizard)
        {
            Console.WriteLine($"Looking at the {lizard.Length} foot {lizard.Color} snake in the aquarium.");
        }

        public void Visit(Fish fish)
        {
            Console.WriteLine($"There's a fish in the tank!");
        }
    }
}
