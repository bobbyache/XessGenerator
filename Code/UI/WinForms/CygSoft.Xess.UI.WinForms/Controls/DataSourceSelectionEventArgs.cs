using System;
using CygSoft.Xess.Infrastructure;

namespace CygSoft.Xess.UI.WinForms.EventParams
{
    public sealed class DataSourceSelectionEventArgs : EventArgs
    {
        private IDataSource selectedDataSource;
        public IDataSource SelectedDataSource
        {
            get { return this.selectedDataSource; }
        }
        public DataSourceSelectionEventArgs(IDataSource dataSource)
        {
            this.selectedDataSource = dataSource;
        }
    }
}
