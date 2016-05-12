using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace CygSoft.Xess.UI.WinForms
{
    public class ResourceHandler
    {
        public const string ResourceNamespaceText = "CygSoft.Xess.UI.WinForms.Resources";

        public class ToolbarImages
        {
            public const string Add = "add";
            public const string Delete = "delete";
            public const string Edit = "edit";
            public const string Clone = "clone";
            public const string Options = "options";
            public const string Generate = "options";
            public const string MoveUp = "arrow_up1";
            public const string MoveDown = "arrow_down";
            public const string ClearSelectedRecords = "page_delete";
            public const string SelectAllRecords = "page_add";
            public const string AddWindowsFolder = "folder_add";
            public const string AddExcelSource = "table_add";
            public const string AddSqlServerSource = "database_add";
            public const string FileDiff = "diff_check";
            public const string GenerateData = "data_refresh";
            public const string DatasourceFolder = "datasource_folder";
            public const string DatasourceDatabase = "datasource_database";
            public const string DatasourceExcel = "datasource_excel";
            public const string SaveOutputFile = "save_output_file";
        }

        public static Image ToolbarIcon(string key)
        {
            ResourceManager resManager = new ResourceManager("CygSoft.Xess.UI.WinForms.Resources", Assembly.GetExecutingAssembly());
            return (Image)resManager.GetObject(key);
        }
    }
}
