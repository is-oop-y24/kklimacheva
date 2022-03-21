using System;

namespace Banks.Operations
{
    public abstract class IOperation
    {
        public IOperation(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public abstract void DoOperation();
        public abstract void UndoOperation();
    }
}