using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks
{
    public class Bank
    {
        private readonly List<IBankAccount> _availableAccounts = new List<IBankAccount>();
        private readonly List<Client> _clients = new List<Client>();
        private readonly List<ClientTransaction> _transactions = new List<ClientTransaction>();

        public Bank(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyList<ClientTransaction> Transactions()
        {
            return _transactions;
        }

        public Client RegisterNewClient(string name, string surname, string passport, string address)
        {
            Client newClient = new Client.Builder()
                .SetName(name)
                .SetSurname(surname)
                .SetPassport(passport)
                .SetAddress(address)
                .GetClient();
            _clients.Add(newClient);
            return newClient;
        }

        public void OpenNewCreditAccount(Client client, BankCreditAccount account, double moneyAmount)
        {
            if (IsSuspicious(client))
            {
                throw new AccountException("Passport and address info needed.");
            }

            client.AddNewAccount(new ClientCreditAccount(account, moneyAmount));
        }

        public void OpenNewDebitAccount(Client client, BankDebitAccount account, double moneyAmount)
        {
            if (IsSuspicious(client))
            {
                throw new AccountException("Passport and address info needed.");
            }

            client.AddNewAccount(new ClientDebitAccount(account, moneyAmount));
        }

        public void OpenNewDepositAccount(Client client, BankDepositAccount account, double moneyAmount)
        {
            if (IsSuspicious(client))
            {
                throw new AccountException("Passport and address info needed.");
            }

            client.AddNewAccount(new ClientDepositAccount(account, moneyAmount));
        }

        public void TransferMoneyInsideBank(Guid from, Guid to, double moneyAmount)
        {
            GetAccountByAccountNumber(from).WithDrawMoney(moneyAmount);
            GetAccountByAccountNumber(to).DepositMoney(moneyAmount);
            RegisterTransaction(from, to, moneyAmount);
        }

        public void CountInterest()
        {
            foreach (IClientAccount account in _clients.SelectMany(client => client.Accounts()))
            {
                account.CountInterest();
            }
        }

        public void MakePayment()
        {
            foreach (IClientAccount account in _clients.SelectMany(client => client.Accounts()))
            {
                account.ProceedPayment();
            }
        }

        public void RegisterTransaction(Guid from, Guid to, double money)
        {
            _transactions.Add(new ClientTransaction(from, to, money));
        }

        public void AddNewAccountType(IBankAccount account)
        {
            _availableAccounts.Add(account);
        }

        public IClientAccount GetAccountByAccountNumber(Guid num)
        {
            foreach (IClientAccount account in from client in _clients from account in client.Accounts() where account.AccountNumber.Equals(num) select account)
            {
                return account;
            }

            throw new AccountException("Account doesn't exist");
        }

        private static bool IsSuspicious(Client client)
        {
            return client.Address == string.Empty || client.Passport == string.Empty;
        }
    }
}