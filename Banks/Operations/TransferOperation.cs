using System;
using Banks.Accounts;

namespace Banks.Operations
{
    public class TransferOperation : IOperation
    {
        private readonly IAccount _sender;
        private readonly IAccount _receiver;
        private readonly int _sum;
        private DateTime? _date;

        public TransferOperation(int id, IAccount sender, IAccount receiver, int sum)
            : base(id)
        {
            _sender = sender;
            _receiver = receiver;
            _sum = sum;
        }

        public override void DoOperation()
        {
            _date = DateTime.Now.Date;
            _sender.Balance -= _sum;
            _receiver.Balance += _sum;
        }

        public override void UndoOperation()
        {
            _date = null;
            _sender.Balance += _sum;
            _receiver.Balance -= _sum;
        }
    }
}