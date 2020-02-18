using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class BeforeController
    {
        private readonly RateCalculator _rateCalculator;

        public BeforeController(RateCalculator rateCalculator)
        {
            _rateCalculator = rateCalculator;
        }

        public void CreateLoan(string name)
        {
            var model = new Loan(_rateCalculator, name);
        }
    }
}
