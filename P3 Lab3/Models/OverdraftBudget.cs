using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    internal class OverdraftBudget : Budget
    {
        private double _overdraftLimit;

        public OverdraftBudget(string name) : base(name)
        {

        }

        public double Overdraft
        {
            get { return _overdraftLimit; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("ERROR: Overdraft cannot be negative!", nameof(value));

                _overdraftLimit = value;
            }
        }

        public override double PayExpense(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(amount));

            if (amount > DivisionBudget + Overdraft)
                throw new ArgumentException("Insufficient funds!", nameof(amount));                                   
            _divisionExpenses += amount;
            _companyExpenses += amount;
            _companyBudget -= amount;
            return _divisionAllowances -= amount;
        }



        public override string ToString()
        {
            return base.ToString() + $"\n{Overdraft}";
        }
    }
}
