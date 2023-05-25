using System;
using System.Collections.Generic;
using Banks.Accounts;
using Banks.Clients;
using Banks.Operations;

namespace Banks.Bank
{
    public class BankConfig
    {
        public BankConfig(string name, double debitPercent, List<(int, double)> depositPercentages, double creditCommission, int creditLimit, double incompleteClientRightsLimit)
        {
            if (creditCommission <= 0) throw new ArgumentOutOfRangeException(nameof(creditCommission));
            DebitPercent = debitPercent;
            CreditCommission = creditCommission;
            CreditLimit = creditLimit;
            IncompleteClientRightsLimit = incompleteClientRightsLimit;
            DepositPercentages = depositPercentages;
            DepositPercentages.Sort();
            Operations = new List<IOperation>();
            Clients = new List<Client>();
            ClientIdAccounts = new Dictionary<int, List<IAccount>>();
        }

        public double DebitPercent { get; }
        public List<(int sum, double percentage)> DepositPercentages { get; }
        public double CreditCommission { get; }
        public double IncompleteClientRightsLimit { get; }
        public List<IOperation> Operations { get; }
        public List<Client> Clients { get; }
        public Dictionary<int, List<IAccount>> ClientIdAccounts { get; }
        public int CreditLimit { get; }
    }
}