namespace Banks
{
    public class BankCreditAccount : IBankAccount
    {
        public BankCreditAccount(double commission)
        {
            Commission = commission;
        }

        public double Commission { get; private set; }
        public double InterestOnBalance { get; }

        public void ChangeInterestOnBalance(double value)
        {
            Commission = value;
        }
    }
}