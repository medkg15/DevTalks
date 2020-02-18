using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Loan
    {
        private readonly RateCalculator _rateCalculator;
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime ApplicationDate { get; }
        public decimal LoanAmount { get; }
        public TimeSpan Term { get; }

        public Loan(RateCalculator rateCalculator, string firstName, string lastName, DateTime applicationDate, decimal loanAmount, TimeSpan term)
        {
            _rateCalculator = rateCalculator;
            FirstName = firstName;
            LastName = lastName;
            ApplicationDate = applicationDate;
            LoanAmount = loanAmount;
            Term = term;
        }

        public decimal TotalCost => _rateCalculator.TotalCost(LoanAmount, Term);

        public decimal MonthlyPayment => _rateCalculator.MonthlyPayment(LoanAmount, Term);
    }
}
