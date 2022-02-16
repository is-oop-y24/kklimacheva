using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks
{
    public sealed class CentralBank
    {
        private static CentralBank _instance;
        private List<Bank> _banks = new List<Bank>();
        private CentralBank() { }

        public static CentralBank GetInstance()
        {
            return _instance ??= new CentralBank();
        }

        public void MakeInterbankTransaction(TransactionData data)
        {
            GetAccountFromBank(data.FromBank, data.From).WithDrawMoney(data.MoneyAmount);
            GetAccountFromBank(data.ToBank, data.To).DepositMoney(data.MoneyAmount);
            data.FromBank.RegisterTransaction(data.From, data.To, data.MoneyAmount);
            data.ToBank.RegisterTransaction(data.From, data.To, data.MoneyAmount);
        }

        public void CancelTransaction(Bank withdrawalBank, Guid transactionId)
        {
            ClientTransaction transaction =
                withdrawalBank.Transactions().FirstOrDefault(trans => transactionId.Equals(trans.Id));

            if (transaction == null)
            {
                throw new TransactionException("Wrong transaction number");
            }

            IClientAccount withdrawalAccount = withdrawalBank.GetAccountByAccountNumber(transaction.From);
            withdrawalAccount.DepositMoney(transaction.Sum);
        }

        public Bank RegisterNewBank(string name)
        {
            var newBank = new Bank(name);
            _banks.Add(newBank);
            return newBank;
        }

        public void PaymentNotification()
        {
            foreach (Bank bank in _banks)
            {
                bank.MakePayment();
            }
        }

        public IReadOnlyList<Bank> Banks()
        {
            return _banks;
        }

        private IClientAccount GetAccountFromBank(Bank bank, Guid accountNum)
        {
            return bank.GetAccountByAccountNumber(accountNum);
        }
    }
}