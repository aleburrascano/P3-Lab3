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
        protected double _divisionAllowances;
        protected double _divisionExpenses;

        protected static double _companyBudget;
        protected static double _companyExpenses;

        private double _deniedDivisionAllowances;
        private static double _companyDeniedAllowances;

        public Budget(string divisionName)
        {
            Name = divisionName;
        }

        public Budget(string divisionName, double startingAllowance)
        {
            Name = divisionName;
            AddAllowance(startingAllowance);
        }

        // Setter for _divisionAllowances
        public double AddAllowance(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(amount));

            if (!AnnualFunds.ApproveAllowance(amount))
            {
                DeniedAllowances += amount;
                CompanyDeniedAllowances += amount;
            }
            else
            {
                _companyBudget += amount;
                _divisionAllowances += amount;
            }

            return _divisionAllowances;
        }

        public virtual double PayExpense(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(amount));

            if (amount > DivisionBudget)
                throw new ArgumentException("Amount cannot be more than the budget!", nameof(amount));

            _divisionExpenses += amount;
            _companyExpenses += amount;
            _companyBudget -= amount;
            return _divisionAllowances -= amount;
        }

        public double DivisionBudget
        {
            get { return _divisionAllowances; }
            protected set { _divisionAllowances = value; }
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

        public double DeniedAllowances
        {
            get { return _deniedDivisionAllowances; }
            set { _deniedDivisionAllowances = value; }
        }

        public static double CompanyDeniedAllowances
        {
            get { return _companyDeniedAllowances; }
            set { _companyDeniedAllowances = value; }
        }

        public override string ToString()
        {
            return $"\n{Name} Division\n{"Budget:",-35} {DivisionBudget,20:C}\n{"Expenses:",-35} {DivisionExpenses,20:C}\n{"Denied Allowances:",-35} {DeniedAllowances,20:C}";
        }
    }
}
