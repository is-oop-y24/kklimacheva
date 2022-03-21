using System;
using Backups;

namespace BackupsExtra
{
    public class HybridRemover : IPointRemover
    {
        private bool _deleteByAllLimits;
        private RemoveByAmount _amountRemover;
        private RemoveByDate _dateRemover;

        public HybridRemover(int n, DateTime time, bool deleteByAllLimits = false)
        {
            _amountRemover = new RemoveByAmount(n);
            _dateRemover = new RemoveByDate(time);
            _deleteByAllLimits = deleteByAllLimits;
        }

        public void Remove(BackupJob job)
        {
            if (_deleteByAllLimits)
            {
                _amountRemover.Remove(job);
                _dateRemover.Remove(job);
                return;
            }

            _amountRemover.Remove(job);
        }
    }
}