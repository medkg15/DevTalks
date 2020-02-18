namespace DependencyInjection._2Manual
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new ObjectB();
            var a = new ObjectA(b);

            a.DoStuff();
        }
    }
}
