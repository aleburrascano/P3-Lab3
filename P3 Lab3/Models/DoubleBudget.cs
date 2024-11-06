using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    internal class DoubleBudget : Budget
    {
        private double _backupAllowance;

        public DoubleBudget(string name) : base(name) 
        {

        }

        public void AddBackupAllowance(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("ERROR: Backup allowance amount cannot be negative!", nameof(amount));

            _backupAllowance = amount;
        }

        public void PayExpenseFromBackup(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("ERROR: Pay amount cannot be negative!", nameof(amount));

            if (amount > _backupAllowance)
                throw new ArgumentException("ERROR: Amount cannot be more than the backup allowance!", nameof(amount));

            _backupAllowance -= amount;
        }

        public double TotalBudget
        {
            get { return _backupAllowance + DivisionBudget; }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nSum of Allowances: {TotalBudget}";
        }
    }
}
