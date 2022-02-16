using System;
using System.Collections.Generic;

namespace Banks
{
    public class Client
    {
        private readonly List<IClientAccount> _clientAccounts = new List<IClientAccount>();
        private Client() { }
        public string Passport { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetPassport(string passport)
        {
            Passport = passport;
        }

        public void OpenNewDebitAccount(Bank bank, BankDebitAccount account, double firstDeposit = 0)
        {
            bank.OpenNewDebitAccount(this, account, firstDeposit);
        }

        public void OpenNewCreditAccount(Bank bank, BankCreditAccount account, double firstDeposit = 0)
        {
            bank.OpenNewCreditAccount(this, account, firstDeposit);
        }

        public void OpenNewDepositAccount(Bank bank, BankDepositAccount account, double firstDeposit = 0)
        {
            bank.OpenNewDepositAccount(this, account, firstDeposit);
        }

        public void AddNewAccount(IClientAccount account)
        {
            _clientAccounts.Add(account);
        }

        public void DepositMoney(IClientAccount account, double sum)
        {
            account.DepositMoney(sum);
        }

        public void WithdrawMoney(IClientAccount account, double sum)
        {
            account.WithDrawMoney(sum);
        }

        public double CalculateMoneyAmountInTimePeriod(IClientAccount account, DateTime date)
        {
            int days = (int)(date.Date - DateTime.Today).TotalDays;
            return account.CalculateMoneyAmountInTimePeriod(days);
        }

        public void TransferMoneyInsideBankSystem(Bank clientsBank, IClientAccount from, Guid to, double moneyAmount)
        {
            if (!AccountExists(from))
            {
                throw new TransactionException("Account doesn't belong to this client");
            }

            from.TransferMoney(clientsBank, to, moneyAmount);
        }

        public void TransferMoneyToAnotherBank(Bank clientsBank, Bank depositBank, CentralBank cb, IClientAccount from, Guid to, double moneyAmount)
        {
            if (!AccountExists(from))
            {
                throw new TransactionException("Account doesn't belong to this client");
            }

            from.TransferMoneyToAnotherBank(cb, clientsBank, depositBank, to, moneyAmount);
        }

        public IReadOnlyList<IClientAccount> Accounts()
        {
            return _clientAccounts;
        }

        private bool AccountExists(IClientAccount account)
        {
            return _clientAccounts.Contains(account);
        }

        public class Builder
        {
            private Client _client = new Client();

            public Builder SetName(string name)
            {
                _client.Name = name;
                return this;
            }

            public Builder SetSurname(string surname)
            {
                _client.Surname = surname;
                return this;
            }

            public Builder SetPassport(string passport)
            {
                _client.Passport = passport;
                return this;
            }

            public Builder SetAddress(string address)
            {
                _client.Address = address;
                return this;
            }

            public Client GetClient()
            {
                if (_client.Name == string.Empty || _client.Surname == string.Empty)
                {
                    throw new ClientException("Invalid name or surname.");
                }

                return _client;
            }
        }
    }
}