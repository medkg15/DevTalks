using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    public class SpecialPlanDisclaimer : MessageGenerator
    {
        public SpecialPlanDisclaimer(MessageGenerator next) : base(next)
        {
        }

        protected override bool IsApplicable(MemberInformation member)
        {
            return member.Plan.StartsWith("X1");
        }

        protected override void Write(TextWriter writer, MemberInformation member)
        {
            writer.WriteLine("Since you're a member of our special plan, we need to tell you some extra important information...");
        }
    }
}
