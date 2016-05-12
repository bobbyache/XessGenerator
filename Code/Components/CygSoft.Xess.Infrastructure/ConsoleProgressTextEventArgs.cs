using System;

namespace CygSoft.Xess.Infrastructure
{
    public class ConsoleProgressTextEventArgs : EventArgs
    {
        private string statusText;
        public string StatusText
        {
            get { return statusText; }
            set { statusText = value; }
        }

        private bool isError;
        public bool IsError
        {
            get { return isError; }
            set { isError = value; }
        }

        public ConsoleProgressTextEventArgs(string statusText, bool isError)
        {
            this.isError = isError;
            this.statusText = statusText;
        }
    }
}
