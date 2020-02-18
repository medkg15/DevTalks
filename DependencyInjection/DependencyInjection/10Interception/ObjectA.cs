namespace DependencyInjection._10Interception
{
    public class ObjectA
    {
        private readonly InterfaceB b;
        private readonly ObjectC _c;

        public ObjectA(InterfaceB b, ObjectC c)
        {
            this.b = b;
            _c = c;
        }

        public void DoStuff()
        {
            // do some stuff

            b.DoStuff();
            _c.DoStuff();
            
            // do some more stuff
        }
    }
}
