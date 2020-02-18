using System;

namespace DependencyInjection._2Manual
{
    public class ObjectA
    {
        private readonly InterfaceB b;

        public ObjectA(InterfaceB b)
        {
            if (b == null)
            {
                throw new ArgumentNullException();
            }
            this.b = b;
        }

        public void DoStuff()
        {
            // do some stuff
            
            b.DoStuff();
            
            // do some more stuff
        }
    }
}
