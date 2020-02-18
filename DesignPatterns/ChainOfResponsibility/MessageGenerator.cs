using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    public abstract class MessageGenerator
    {
        private readonly MessageGenerator _next;

        protected MessageGenerator(MessageGenerator next)
        {
            _next = next;
        }

        protected abstract bool IsApplicable(MemberInformation member);

        protected abstract void Write(TextWriter writer, MemberInformation member);

        public void GenerateMessage(TextWriter writer, MemberInformation member)
        {
            if (IsApplicable(member))
            {
                Write(writer, member);
            }

            if (_next != null)
            {
                _next.GenerateMessage(writer, member);
            }
        }
    }
}
