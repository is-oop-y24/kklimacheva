using System;

namespace Banks.Accounts
{
    public class CreditAccount : IAccount
    {
        public CreditAccount(int id, int balance, int limit, double commission)
            : base(id, balance)
        {
            Limit = limit;
            Commission = commission;
        }

        public int Limit { get; }
        public double Commission { get; }
        public int CalculateCommission(int sum) => (int)(sum * Commission / 100);
        public override void ClearProfit() { }
        public override bool IsWithdrawAvailable(int sum)
        {
            return true;
        }

        public override void CalculateDayProfit()
        {
            return;
        }

        public override int PayProfit()
        {
            return 0;
        }

        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}