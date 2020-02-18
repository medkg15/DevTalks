namespace DependencyInjection._4Problem
{
    public class ObjectA
    {
        private readonly ObjectB b;

        public ObjectA(ObjectB b)
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
