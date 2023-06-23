namespace DependencyInjection._09Netcore
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
