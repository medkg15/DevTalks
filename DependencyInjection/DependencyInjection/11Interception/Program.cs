using System;
using System.Runtime.CompilerServices;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace DependencyInjection._10Interception
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel())
            {
                // an interceptor can be used to automatically generate decorator classes
                var interceptor = new ActionInterceptor(invocation =>
                {
                    Console.WriteLine("Before " + invocation.Request.Method.DeclaringType.Name + "." + invocation.Request.Method.Name);
                    invocation.Proceed();
                    Console.WriteLine("After" + invocation.Request.Method.DeclaringType.Name + "." + invocation.Request.Method.Name);
                });

                kernel.Bind<InterfaceB>().To<ObjectB>()
                    .Intercept().With(interceptor);

                // the benefit is that we can write an interceptor once, not a decorator per interface
                // this is useful for cross-cutting concerns like auditing, logging, etc.
                // gotcha: ObjectC.DoStuff needs to be virtual, since its a concrete class.  the dynamic proxy can only intercept virtual methods.
                kernel.Bind<ObjectC>().ToSelf()
                    .Intercept().With(interceptor);

                var a = kernel.Get<ObjectA>();
                
                a.DoStuff();
            }
        }
    }
}
