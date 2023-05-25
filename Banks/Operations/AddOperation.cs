using System;
using Banks.Accounts;

namespace Banks.Operations
{
    public class AddOperation : IOperation
    {
        private readonly IAccount _account;
        private readonly int _sum;
        private DateTime? _date;

        public AddOperation(int id, IAccount account, int sum)
            : base(id)
        {
            _account = account;
            _sum = sum;
        }

        public void DoOperation(DateTime operationDate)
        {
            _date = operationDate;
            _account.Balance += _sum;
        }

        public override void DoOperation()
        {
            _date = DateTime.Now.Date;
            _account.Balance += _sum;
        }

        public override void UndoOperation()
        {
            _date = null;
            _account.Balance -= _sum;
        }
    }
}