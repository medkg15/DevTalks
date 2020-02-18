using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    public class OutOfState : MessageGenerator
    {
        public OutOfState(MessageGenerator next) : base(next)
        {
        }

        protected override bool IsApplicable(MemberInformation member)
        {
            return member.State != "CT";
        }

        protected override void Write(TextWriter writer, MemberInformation member)
        {
            writer.WriteLine("Since you're an out-of-state member, ...");
        }
    }
}
