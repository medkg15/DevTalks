namespace DependencyInjection._09Netcore
{
    public class ObjectB : InterfaceB
    {
        private readonly ObjectC _c;
        private readonly ObjectD _d;

        public ObjectB(ObjectC c, ObjectD d)
        {
            _c = c;
            _d = d;
        }

        public virtual void DoStuff()
        {
            _c.DoStuff();
            _d.DoStuff();
        }
    }
}
