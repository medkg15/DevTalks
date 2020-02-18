using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IRateCalculator
    {
        decimal TotalCost(in decimal loanAmount, in TimeSpan term);

        decimal MonthlyPayment(in decimal loanAmount, in TimeSpan term);
    }
}
