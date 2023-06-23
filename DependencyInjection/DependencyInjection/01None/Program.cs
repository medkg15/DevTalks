using System;

namespace DependencyInjection._1None
{
    class Program
    {
        static void Main(string[] args)
        {
            //ObjectA a = new ObjectA();

            Type type = Type.GetType(Console.ReadLine());

            object a = Activator.CreateInstance(type);
        }
    }
}
