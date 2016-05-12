using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class AfterDatasourceGenerateEventArgs : EventArgs
    {
        public IDataSource DataSource { get; private set; }
        public string Text { get; private set; }

        public AfterDatasourceGenerateEventArgs(IDataSource dataSource, string text)
        {
            this.DataSource = dataSource;
            this.Text = text;
        }
    }
}
