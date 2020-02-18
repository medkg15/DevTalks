using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection._5Ninject
{
    public class BetterObjectB : ObjectB
    {
        public BetterObjectB(ObjectC c, ObjectD d) : base(c, d)
        {
            
        }
    }
}
