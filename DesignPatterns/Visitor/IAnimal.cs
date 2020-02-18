using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IAnimal
    {
        void Accept(IAnimalVisitor visitor);

        void Visit(bool isZookeeper);
    }
}
