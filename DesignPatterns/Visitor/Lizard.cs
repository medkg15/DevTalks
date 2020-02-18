using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class Lizard : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Color { get; set; }
        public int Length { get; set; }
    }
}
