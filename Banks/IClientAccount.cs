using System;

namespace Banks
{
    public interface IClientAccount
    {
        Guid AccountNumber { get; }
        void WithDrawMoney(double moneyAmount);
        void DepositMoney(double moneyAmount);
        void TransferMoney(Bank bank, Guid to, double moneyAmount);
        void TransferMoneyToAnotherBank(CentralBank cb, Bank fromBank, Bank toBank, Guid toAccount, double moneyAmount);
        double CalculateMoneyAmountInTimePeriod(int days);
        void ProceedPayment();
        void CountInterest();
    }
}