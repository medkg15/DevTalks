using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class LoanFactory
    {
        private readonly RateCalculator _rateCalculator;

        public LoanFactory(RateCalculator rateCalculator)
        {
            _rateCalculator = rateCalculator;
        }

        public Loan Create(string name)
        {
            return new Loan(_rateCalculator, name);
        }
    }
}
