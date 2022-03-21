using System;
using Banks.Accounts;

namespace Banks.Operations
{
    public class WithdrawOperation : IOperation
    {
        private readonly IAccount _account;
        private readonly int _sum;
        private DateTime? _date;

        public WithdrawOperation(int id, IAccount account, int sum)
            : base(id)
        {
            _date = DateTime.Now.Date;
            _account = account;
            _sum = sum;
        }

        public override void DoOperation()
        {
            _date = DateTime.Now;
            _account.Balance -= _sum;
        }

        public override void UndoOperation()
        {
            _date = null;
            _account.Balance += _sum;
        }
    }
}