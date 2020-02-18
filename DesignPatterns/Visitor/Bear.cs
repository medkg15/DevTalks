using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class Bear : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Breed { get; set; }
    }
}
