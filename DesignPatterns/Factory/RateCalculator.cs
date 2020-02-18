using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class RateCalculator : IRateCalculator
    {
        public decimal TotalCost(in decimal loanAmount, in TimeSpan term)
        {
            throw new NotImplementedException();
        }

        public decimal MonthlyPayment(in decimal loanAmount, in TimeSpan term)
        {
            throw new NotImplementedException();
        }
    }
}
