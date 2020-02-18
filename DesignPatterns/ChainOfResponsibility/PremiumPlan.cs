using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    class PremiumPlan : MessageGenerator
    {
        public PremiumPlan(MessageGenerator next) : base(next)
        {
        }

        protected override bool IsApplicable(MemberInformation member)
        {
            return member.Plan.EndsWith("P");
        }

        protected override void Write(TextWriter writer, MemberInformation member)
        {
            writer.WriteLine("Your premium of {0} is due on the first of each month.  Please visit our website to set up payments, or call XXX-XXX-XXXX.");
        }
    }
}
