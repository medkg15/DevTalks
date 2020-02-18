using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection._4Problem
{
    public class ObjectD
    {
        private readonly ObjectC _c;

        public ObjectD(ObjectC c)
        {
            _c = c;
        }

        public void DoStuff()
        {
            _c.DoStuff();
        }
    }
}
