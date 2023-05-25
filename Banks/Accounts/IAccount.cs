namespace Banks.Accounts
{
    public abstract class IAccount
    {
        public IAccount(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }

        public int Id { get; }
        public double Balance { get; set; }
        public abstract void ClearProfit();
        public abstract bool IsWithdrawAvailable(int sum);

        public abstract void CalculateDayProfit();
        public abstract int PayProfit();
        public abstract int CalcNewSum(int sum);
    }
}