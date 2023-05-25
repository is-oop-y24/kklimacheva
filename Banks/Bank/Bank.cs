using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Accounts;
using Banks.Clients;
using Banks.Exceptions;
using Banks.Operations;

namespace Banks.Bank
{
    public class Bank
    {
        private static int _idCounter;
        private readonly double _creditCommission;
        public Bank(string name, double debitPercentage, List<(int, double)> depositPercentages, double creditCommission, int creditLimit, double incompleteClientRightsLimit)
        {
            _creditCommission = creditCommission;
            BankConfig = new BankConfig(name, debitPercentage, depositPercentages, creditCommission, creditLimit, incompleteClientRightsLimit);
        }

        private BankConfig BankConfig { get; }

        public void AddClient(Client client)
        {
            BankConfig.Clients.Add(client);
            BankConfig.ClientIdAccounts[client.Id] = new List<IAccount>();
        }

        public void AddAccount(Client client, IAccount account)
        {
            if (!BankConfig.ClientIdAccounts.ContainsKey(client.Id))
                throw new WrongIdException("Client Id " + client.Id + " don't exists");
            BankConfig.ClientIdAccounts[client.Id].Add(account);
        }

        public DebitAccount CreateDebitAccount(Client client, int sum)
        {
            if (!CheckClient(client))
            {
                throw new AccountException("More client info needed (passport and address).");
            }

            return new DebitAccount(_idCounter++, sum, BankConfig.DebitPercent);
        }

        public DepositAccount CreateDepositAccount(Client client, int sum, int period)
        {
            if (!CheckClient(client))
            {
                throw new AccountException("More client info needed (passport and address).");
            }

            double percentage = (from depositPercentage in BankConfig.DepositPercentages where sum < depositPercentage.sum select depositPercentage.percentage).FirstOrDefault();

            if (percentage == 0)
                percentage = BankConfig.DepositPercentages[1].percentage;
            return new DepositAccount(_idCounter++, sum, percentage, period);
        }

        public CreditAccount CreateCreditAccount(Client client, int sum)
        {
            if (!CheckClient(client))
            {
                throw new AccountException("More client info needed (passport and address).");
            }

            return new CreditAccount(_idCounter++, sum, BankConfig.CreditLimit, BankConfig.CreditCommission);
        }

        public int GetLastOperationId()
        {
            IOperation last = BankConfig.Operations.Last();
            return last.Id;
        }

        public int AddMoney(IAccount depositor, int sum)
        {
            if (!TryGetClientAccount(depositor.Id, out Client client, out IAccount account))
                throw new AccountException("Account Id " + account.Id + " don't exists");
            var operation = new AddOperation(_idCounter, account, sum);
            operation.DoOperation();
            BankConfig.Operations.Add(operation);
            return _idCounter++;
        }

        public int WithdrawMoney(IAccount acc, int sum)
        {
            if (!TryGetClientAccount(acc.Id, out Client client, out IAccount account)
                && !CheckClient(client)
                && sum > BankConfig.IncompleteClientRightsLimit
                && !account.IsWithdrawAvailable(sum))
                throw new UnsuccessfulWithdrawalException("Can't withdraw from account " + account.Id);
            sum = account.CalcNewSum(sum);
            var withdrawOperation = new WithdrawOperation(_idCounter, account, sum);
            withdrawOperation.DoOperation();
            BankConfig.Operations.Add(withdrawOperation);
            return _idCounter++;
        }

        public int TransferMoney(IAccount sender, IAccount recipient, int sum)
        {
            int id1 = sender.Id;
            int id2 = recipient.Id;
            if (!TryGetClientAccount(id1, out Client client1, out IAccount account1)
                && !account1.IsWithdrawAvailable(sum) && !TryGetClientAccount(id2)
                && !CheckClient(client1) && sum > BankConfig.IncompleteClientRightsLimit)
            {
                throw new UnsuccessfulWithdrawalException("Can't transfer from this account " + account1.Id);
            }

            var transferOperation = new TransferOperation(_idCounter, sender, recipient, sum);
            transferOperation.DoOperation();
            BankConfig.Operations.Add(transferOperation);
            return _idCounter++;
        }

        public void UndoOperation(int id)
        {
            int pos = BankConfig.Operations.FindIndex(operation => operation.Id == id);
            if (pos == -1)
                throw new WrongIdException("Operation Id " + id + " don't exists");
            BankConfig.Operations[pos].UndoOperation();
            BankConfig.Operations.RemoveAt(pos);
        }

        private void ProfitClear(DateTime newDate, DateTime lastUpdateDate)
        {
            if ((newDate.Year == lastUpdateDate.Year && (newDate.Month != lastUpdateDate.Month))
                || newDate.Year != lastUpdateDate.Year)
            {
                foreach (IAccount account in BankConfig.ClientIdAccounts.Values.SelectMany(accounts => accounts))
                {
                    account.ClearProfit();
                }
            }
        }

        private bool CheckClient(Client client)
        {
            return !string.IsNullOrEmpty(client?.Address) || !string.IsNullOrEmpty(client?.Passport);
        }

        private Client GetClient(int id)
        {
            return BankConfig.Clients.Find(client => client.Id == id);
        }

        private bool TryGetClientAccount(int id, out Client client, out IAccount acc)
        {
            foreach ((int key, List<IAccount> value) in BankConfig.ClientIdAccounts)
            {
                foreach (IAccount account in value.Where(account => account.Id == id))
                {
                    client = GetClient(key);
                    acc = account;
                    return true;
                }
            }

            client = null;
            acc = null!;
            return false;
        }

        private bool TryGetClientAccount(int id)
        {
            return BankConfig.ClientIdAccounts.SelectMany(clientAccount => clientAccount.Value).Any(account => account.Id == id);
        }
    }
}