using Ninject;

namespace DependencyInjection._5Ninject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel(new Module1))
            {
                // specify bindings from interfaces to implementations
                kernel.Bind<InterfaceB>().To<ObjectB>();

                // we can also override past bindings
                kernel.Unbind<InterfaceB>();
                kernel.Bind<InterfaceB>().To<BetterObjectB>();

                // ask the kernel for the root object.  it will automatically inspect A's dependencies, those class's dependencies, etc., and create them all.
                var a = kernel.Get<ObjectA>();

                a.DoStuff();
            }
        }
    }
}
