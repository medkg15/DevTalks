using DependencyInjection._1None;

namespace DependencyInjection._6FuncContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<InterfaceB>(() => new ObjectB());
            container.Register(() => new ObjectA(container.Get<InterfaceB>()));

            var a = container.Get<ObjectA>();

            a.DoStuff();
        }
    }
}
