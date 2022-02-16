using System;

namespace Banks
{
    public class ClientCreditAccount : IClientAccount
    {
        private BankCreditAccount _bankAccountInstance;

        public ClientCreditAccount(BankCreditAccount bankAccount, double balance = 0)
        {
            AccountNumber = Guid.NewGuid();
            Balance = balance;
            _bankAccountInstance = bankAccount;
        }

        public Guid AccountNumber { get; }
        public double Balance { get; private set; }
        public void WithDrawMoney(double moneyAmount)
        {
            Balance -= moneyAmount;
        }

        public void DepositMoney(double moneyAmount)
        {
            Balance += moneyAmount;
        }

        public void TransferMoney(Bank bank, Guid to, double moneyAmount)
        {
            bank.TransferMoneyInsideBank(AccountNumber, to, moneyAmount);
        }

        public void TransferMoneyToAnotherBank(CentralBank cb, Bank fromBank, Bank toBank, Guid toAccount, double moneyAmount)
        {
            var newData = new TransactionData(fromBank, toBank, AccountNumber, toAccount, moneyAmount);
            cb.MakeInterbankTransaction(newData);
        }

        public double CalculateMoneyAmountInTimePeriod(int days)
        {
            return Balance;
        }

        public void ProceedPayment()
        {
            if (Balance < 0)
            {
                Balance -= _bankAccountInstance.Commission;
            }
        }

        public void CountInterest()
        {
        }
    }
}