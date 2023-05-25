namespace Banks.Accounts
{
    public class DebitAccount : IAccount
    {
        private double _profit;
        public DebitAccount(int id, int balance, double percentage)
            : base(id, balance)
        {
            Percentage = percentage;
            _profit = 0;
        }

        public double Percentage { get; }

        public override void CalculateDayProfit()
        {
            _profit += Balance * Percentage / 365 / 100;
        }

        public override int PayProfit()
        {
            var profitPay = _profit;
            _profit = 0;
            return (int)profitPay;
        }

        public override void ClearProfit()
        {
            _profit = 0;
        }

        public override bool IsWithdrawAvailable(int sum)
        {
            return Balance >= sum;
        }

        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}