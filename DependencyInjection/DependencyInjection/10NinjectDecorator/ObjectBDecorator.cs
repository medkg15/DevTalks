using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection._09NinjectDecorator
{
    public class ObjectBDecorator : InterfaceB
    {
        private readonly InterfaceB _b;

        public ObjectBDecorator(InterfaceB b)
        {
            _b = b;
        }

        public void DoStuff()
        {
            // do before stuff

            _b.DoStuff();

            // do after stuff
        }
    }
}
