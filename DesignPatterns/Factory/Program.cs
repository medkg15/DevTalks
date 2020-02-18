using System;
using Ninject;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            using var kernel = new StandardKernel();
            kernel.Bind<IRateCalculator>().To<RateCalculator>();

            var controller = kernel.Get<BeforeController>();

            controller.DoStuff("stuff");

            //var controller = kernel.Get<AfterController>();

            //controller.DoStuff("stuff");
        }
    }
}
