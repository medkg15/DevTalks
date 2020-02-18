using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IAnimalVisitor
    {
        void Visit(Bear bear);
        void Visit(Lizard lizard);
        void Visit(Fish fish);
    }
}
