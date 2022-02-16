using System;
using System.Collections.Generic;

namespace Banks
{
    public class BankDepositAccount : IBankAccount
    {
        private DateTime _expirationDate;
        private SortedDictionary<double, double> _interestConditions;

        public BankDepositAccount(SortedDictionary<double, double> interestConditions, DateTime expirationDate)
        {
            _interestConditions = interestConditions;
            _expirationDate = expirationDate;
        }

        public double Commission { get; }
        public double InterestOnBalance { get; }

        public void AddNewCondition(double sum, double percentage)
        {
            _interestConditions.Add(sum, percentage);
        }

        public IReadOnlyDictionary<double, double> InterestConditions()
        {
            return _interestConditions;
        }

        public bool IsActive()
        {
            return !DateTime.Today.Equals(_expirationDate);
        }

        public void ChangeInterestOnBalance(double value)
        {
        }
    }
}