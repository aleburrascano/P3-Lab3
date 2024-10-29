using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Lab3.Models
{
    static class AnnualFunds
    {
        private const double ALL_FUNDS = 300000;
        private static double availableFunds = ALL_FUNDS;
        private const int PASS_CODE = 2024;

        public static double AvailableFunds
        {
            get { return availableFunds; }
        }

        public static bool ApproveAllowance(double allowanceAmount)
        {
            if (allowanceAmount < 0)
                throw new ArgumentException("Amount cannot be zero or negative!", nameof(allowanceAmount));

            if (allowanceAmount > availableFunds)
                return false;

            availableFunds -= allowanceAmount;
            return true;
        }

        public static bool ResetFunds(int passcode)
        {
            if (passcode != PASS_CODE)
                return false;
            
            availableFunds = ALL_FUNDS;
            return true;
        }
    }
}
