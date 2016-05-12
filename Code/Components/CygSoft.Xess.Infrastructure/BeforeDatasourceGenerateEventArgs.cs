using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class BeforeDatasourceGenerateEventArgs : EventArgs
    {
        public IDataSource DataSource { get; private set; }
        public string Text { get; private set; }
        public bool Cancel { get; set; }

        public BeforeDatasourceGenerateEventArgs(IDataSource dataSource)
        {
            this.Cancel = false;
            this.DataSource = dataSource;
        }
    }
}
