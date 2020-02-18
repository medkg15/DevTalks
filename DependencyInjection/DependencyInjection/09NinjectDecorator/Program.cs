using Ninject;

namespace DependencyInjection._09NinjectDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<InterfaceB>().To<ObjectBDecorator>();

                kernel.Bind<InterfaceB>().To<ObjectB>()
                    .WhenInjectedExactlyInto<ObjectBDecorator>();
                
                var a = kernel.Get<ObjectA>();

                a.DoStuff();
            }
        }
    }
}
