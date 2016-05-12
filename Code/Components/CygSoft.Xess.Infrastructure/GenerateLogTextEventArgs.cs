using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygX1.Xess.Infrastructure
{
    public class GenerateLogTextEventArgs : EventArgs
    {
        public string LogMessage { get; private set; }
        public bool IsError { get; private set; }
        public GenerateLogTextEventArgs(string logMessage, bool isError)
        {
            this.IsError = isError;
            this.LogMessage = logMessage;
        }
    }
}
