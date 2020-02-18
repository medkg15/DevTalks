using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new GoogleMapsApiParser();
            var printer = new LetterPrinter(parser, Console.Out);

            var letter = new Letter
            {
                RecipientName = "John Smith",
                ToAddress = "123 Main Street Hartford CT, 06101",
                Body = "Greeting John, ...",
            };

            printer.Print(letter);

            /*
             John Smith
            123 Main St
            Hartford CT, 06101
            -----------
            Greeting John, ...
             */
        }
    }
}
