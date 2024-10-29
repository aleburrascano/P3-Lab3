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

        private double _deniedDivisionAllowances;
        private static double _companyDeniedAllowances;

        public Budget(string divisionName)
        {
            Name = divisionName;
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

        public double PayExpense(double amount)
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
            set
            {
                _deniedDivisionAllowances = value;
            }
        }

        public static double CompanyDeniedAllowances
        {
            get { return _companyDeniedAllowances; }
            set
            {
                _companyDeniedAllowances = value;
            }
        }

        public override string ToString()
        {
            return $"\n{Name} Division\nBudget:    {DivisionBudget,20:C}\nExpenses: {DivisionExpenses,20:C}\nDenied Allowances: {DeniedAllowances,20:C}";
        }
    }
}
