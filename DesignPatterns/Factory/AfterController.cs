using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class AfterController
    {
        private readonly LoanFactory _loanFactory;

        public AfterController(LoanFactory loanFactory)
        {
            _loanFactory = loanFactory;
        }

        public void DoStuff(string name)
        {
            var loan = _loanFactory.Create(name);
        }
    }
}
