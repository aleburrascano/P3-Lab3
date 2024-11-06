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


    }
}
