using CygSoft.Xess.Infrastructure;
using System;

namespace CygSoft.Xess.Domain.Generators
{
    public class DataSourceGenerator
    {
        public event EventHandler<BeforeDatasourceGenerateEventArgs> BeforeGenerate;
        public event EventHandler<ConsoleProgressTextEventArgs> ProgressMessage;
        public event EventHandler<PercentCompleteEventArgs> PercentComplete;
        public event EventHandler<AfterDatasourceGenerateEventArgs> AfterGenerate;

        public bool Generate(IDataSource dataSource)
        {
            if (BeforeGenerate != null)
                BeforeGenerate(this, new BeforeDatasourceGenerateEventArgs(dataSource));
            
            try
            {
                if (dataSource.SourceIsValid())
                {
                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("Retrieving data for {0}...", dataSource.Title), false));
                    dataSource.FetchData();

                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("Updating data for {0}...", dataSource.Title), false));
                    dataSource.WriteFileData();

                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs("...success!.", false));

                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("File updated: {0}", dataSource.DatasetFilePath), false));
                }
                else
                {
                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs("...failure!. Source is invalid.", true));

                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...failure!. Error:{0}{1}", Environment.NewLine, ex.Message) , true));

                return false;
            }

            if (AfterGenerate != null)
                AfterGenerate(this, new AfterDatasourceGenerateEventArgs(dataSource, ""));

            return true;
        }

        public bool Generate(IDataSource[] dataSourceList)
        {
            if (dataSourceList.Length > 0)
            {
                for (int x = 0; x < dataSourceList.Length; x++)
                {
                    bool success = Generate(dataSourceList[x]);

                    if (!success) return false;

                    if (PercentComplete != null)
                        PercentComplete(this, new PercentCompleteEventArgs(x + 1, dataSourceList.Length));
                }
            }
            return true;
        }
    }
}
