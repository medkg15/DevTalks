using System;
using System.IO;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Greeting( 
                new OutOfState(
                    new PremiumPlan(
                        new SpecialPlanDisclaimer( 
                            null))));

            var member = new MemberInformation
            {
                Name = "Sally Smith",
                County = "Hartford",
                Plan = "X1234",
                State = "CT",
            };

            generator.GenerateMessage(Console.Out, member);

            Console.WriteLine("---------------");

            member = new MemberInformation
            {
                Name = "John Smith",
                County = "New Haven",
                Plan = "X1234P",
                State = "CT",
            };

            generator.GenerateMessage(Console.Out, member);

            Console.WriteLine("---------------");

            member = new MemberInformation
            {
                Name = "Joan Smith",
                County = "Litchfield",
                Plan = "1234P",
                State = "CT",
            };

            generator.GenerateMessage(Console.Out, member);

            Console.WriteLine("---------------");

            member = new MemberInformation
            {
                Name = "Richard Smith",
                County = "Kings",
                Plan = "1234P",
                State = "NY",
            };

            generator.GenerateMessage(Console.Out, member);
        }
    }
}
