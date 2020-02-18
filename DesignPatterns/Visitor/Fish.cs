using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public class Fish : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
