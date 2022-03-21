using System.Collections.Generic;

namespace Banks.Bank
{
    public class CentralBank
    {
        private static CentralBank _instance = null!;
        private List<Bank> _banks = new List<Bank>();
        private CentralBank() { }
        public static CentralBank GetInstance()
        {
            return _instance ??= new CentralBank();
        }

        public Bank RegisterNewBank(string name, double debitPercentage, List<(int, double)> depositPercentages, double creditCommission, int creditLimit, double incompleteClientRightsLimit)
        {
            var newBank = new Bank(name, debitPercentage, depositPercentages, creditCommission, creditLimit, incompleteClientRightsLimit);
            _banks.Add(newBank);
            return newBank;
        }

        public IReadOnlyList<Bank> Banks()
        {
            return _banks;
        }
    }
}