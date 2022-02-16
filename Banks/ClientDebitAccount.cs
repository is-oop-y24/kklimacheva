using System;

namespace Banks
{
    public class ClientDebitAccount : IClientAccount
    {
        private BankDebitAccount _bankAccountInstance;
        private double _currentPayment;

        public ClientDebitAccount(BankDebitAccount bankAccount, double balance = 0)
        {
            AccountNumber = Guid.NewGuid();
            _bankAccountInstance = bankAccount;
            Balance = balance;
        }

        public Guid AccountNumber { get; }

        public double Balance { get; private set; }

        public void WithDrawMoney(double moneyAmount)
        {
            if (Balance < moneyAmount)
            {
                throw new TransactionException("Not enough money.");
            }

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
            double res = Balance;
            double currentState = _currentPayment;
            for (int i = 0; i < days; ++i)
            {
                CountInterest();
                res += _currentPayment;
            }

            _currentPayment = currentState;
            return res + Balance;
        }

        public void ProceedPayment()
        {
            Balance += _currentPayment;
            _currentPayment = 0;
        }

        public void CountInterest()
        {
            double percentage = _bankAccountInstance.InterestOnBalance * 0.01 / 365;
            _currentPayment = Balance * percentage;
        }
    }
}