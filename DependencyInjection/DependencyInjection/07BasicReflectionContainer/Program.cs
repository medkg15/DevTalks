namespace DependencyInjection._7BasicReflectionContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            var a = container.Get<ObjectA>();

            a.DoStuff();
        }
    }
}
