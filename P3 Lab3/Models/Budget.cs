using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    internal class Budget
    {
        private string _divisionName;
        private double _divisionAllowances;
        private double _divisionExpenses;

        private static double _companyBudget;
        private static double _companyExpenses;

        public Budget(string divisionName)
        {
            Name = divisionName;
        }

        // Setter for _divisionAllowances
        public double AddAllowance(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(amount));

            _companyBudget += amount;
            return _divisionAllowances += amount;
        }

        public double PayExpense(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(amount));

            if (amount > DivisionBudget)
                throw new ArgumentException("Amount cannot be more than the budget!", nameof(amount));

            _divisionAllowances -= amount;
            _companyBudget -= amount;

            _companyExpenses += amount;
            return _divisionExpenses += amount;
        }

        public double DivisionBudget
        {
            get { return _divisionAllowances; }
        }

        public double DivisionExpenses
        {
            get { return _divisionExpenses; }
        }

        public string Name
        {
            get { return _divisionName; }
            set { _divisionName = value; }
        }

        public static double CompanyBudget
        {
            get { return _companyBudget; }
        }

        public static double CompanyExpenses
        { 
            get { return _companyExpenses; } 
        }

        public override string ToString()
        {
            return $"Division {Name}\nBudget:    {DivisionBudget,20:C}\nExpenses: {DivisionExpenses,20:C}";
        }
    }
}
