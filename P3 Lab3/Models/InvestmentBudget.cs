using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    internal class InvestmentBudget : Budget
    {
        private double _interestRate;
        private DateTime _maturityDate;

        public InvestmentBudget(string name) : base(name) 
        {
            
        }

        public double Interest
        {
            get
            {
                return _interestRate;
            }
            set
            {
                if (value > 0 && value < 1)
                {
                    _interestRate = value;
                }

                _interestRate = 0;
            }
        }

        public DateTime MaturityDate
        {
            get; set;
        }

        public void AddInterestToAllowance()
        {
            if (DateTime.Now >= _maturityDate)
            {
                base.AddAllowance(((1 + Interest) * base.DivisionBudget));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nInterest Rate: {Interest:P}" + $"\nMaturity Date: {MaturityDate}";
        }
    }
}
