
using System;

namespace DependencyInjection._10Interception
{
    public class ObjectB : InterfaceB
    {
        public virtual void DoStuff()
        {
            Console.WriteLine("B doing stuff.");
        }
    }
}
