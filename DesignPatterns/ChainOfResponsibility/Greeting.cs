using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    public class Greeting : MessageGenerator
    {
        public Greeting(MessageGenerator next) : base(next)
        {

        }

        protected override bool IsApplicable(MemberInformation member)
        {
            return true;
        }

        protected override void Write(TextWriter writer, MemberInformation member)
        {
            writer.WriteLine($"{member.Name},");
            writer.WriteLine("Welcome to our health plan!  We're very happy to have you.");
        }
    }
}
