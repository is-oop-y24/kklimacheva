namespace Banks
{
    public interface IBankAccount
    {
        double Commission { get; }
        double InterestOnBalance { get; }
        void ChangeInterestOnBalance(double value);
    }
}