using System;

namespace Banks
{
    public class TransactionData
    {
        public TransactionData(Bank bankFrom, Bank toBank, Guid from, Guid to, double moneyAmount)
        {
            FromBank = bankFrom;
            ToBank = toBank;
            From = from;
            To = to;
            MoneyAmount = moneyAmount;
        }

        public Bank FromBank { get; }
        public Bank ToBank { get; }
        public Guid From { get; }
        public Guid To { get; }
        public double MoneyAmount { get; }
    }
}