namespace Banks
{
    public class BankDebitAccount : IBankAccount
    {
        public BankDebitAccount(double interestOnBalance)
        {
            InterestOnBalance = interestOnBalance;
        }

        public double Commission { get; }

        public double InterestOnBalance { get; private set; }

        public void ChangeInterestOnBalance(double interest)
        {
            InterestOnBalance = interest;
        }
    }
}