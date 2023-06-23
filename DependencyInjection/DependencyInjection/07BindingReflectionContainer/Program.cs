namespace DependencyInjection._08BindingReflectionContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Bind<ObjectB, BetterObjectB>();

            var a = container.Get<ObjectA>();

            a.DoStuff();
        }
    }
}
