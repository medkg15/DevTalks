using DependencyInjection._03Benefits;

namespace DependencyInjection._4Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new ObjectC();
            var d = new ObjectD(c);
            var b = new ObjectB(c, d);
            var a = new ObjectA(b);

            // however, creating the object graph can become tedious as our dependency trees get deeper (and wider)

            // how do i create object A?
            // what dependencies does object A have?
            // how do i create object B, when I find that Object A depends on it.



            a.DoStuff();
        }
    }
}
