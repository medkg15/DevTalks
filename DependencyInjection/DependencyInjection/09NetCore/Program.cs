using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace DependencyInjection._09Netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<InterfaceB, ObjectB>();
            // microsoft requires binding concrete classes
            services.AddTransient<ObjectA, ObjectA>();
            // services.AddTransient<ObjectA>(); shortcut

            using (var provider = services.BuildServiceProvider())
            {
                var a = provider.GetRequiredService<ObjectA>();

                // ask the provider for the root object.  it will automatically inspect A's dependencies, those class's dependencies, etc., and create them all.
                a.DoStuff();
            }
        }
    }
}
