namespace DependencyInjection._03Benefits
{
    class Program
    {
        static void Main(string[] args)
        {
            //var b = new ObjectB();
            var b = new BetterObjectB();
            var a = new ObjectA(b);

            // we were able to change the behavior of the program (and specifically ObjectA) without modifying A's code (Open/Close principle / De-coupling).
            // this can be extremely powerful, especially with multiple developers / teams / third party libraries.
            // sometimes you can't edit ObjectA, but you can supply a BetterObjectB.

            a.DoStuff();
        }
    }
}
