using DependencyInjection._1None;

namespace DependencyInjection._6FuncContainer
{
    public class ObjectA
    {
        private readonly InterfaceB b;

        public ObjectA(InterfaceB b)
        {
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
