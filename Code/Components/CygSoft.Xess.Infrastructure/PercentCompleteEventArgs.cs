using System;

namespace CygSoft.Xess.Infrastructure
{
    public class PercentCompleteEventArgs : EventArgs
    {
        public double Percentage { get; private set; }
        public string ProgressText { get; private set; }

        public PercentCompleteEventArgs(int position, int count)
        {
            double percentage = 0;
            try
            {
                percentage = Math.Round(((double)position / (double)count) * 100f);
            }
            catch (DivideByZeroException) { }

            this.ProgressText = string.Format("{0} of {1}", position, count);
            this.Percentage = percentage > 100f ? 100f : percentage;
        }
    }
}
