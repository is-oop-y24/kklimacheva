namespace Banks.Accounts
{
    public class DepositAccount : IAccount
    {
        private double _profit;
        public DepositAccount(int id, int balance, double persentage, int period)
            : base(id, balance)
        {
            Persentage = persentage;
            Period = period;
        }

        public double Persentage { get; }
        public int Period { get; }

        public override void CalculateDayProfit()
        {
            _profit += Balance * Persentage / 365 / 100;
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
            return Balance >= sum && Period == 0;
        }

        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}