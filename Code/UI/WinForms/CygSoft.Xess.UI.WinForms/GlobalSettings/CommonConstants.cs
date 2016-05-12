using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CygSoft.Xess.UI.WinForms.GlobalSettings
{
    public class CommonConstants
    {
        public class DialogMessages
        {
            public const string FileSavedNotification = "File has been saved.";
            public const string SuccessTestingConnection = "Test connection succeeded.";
            public const string FailureTestingConnection = "Failed to connect to SQL Server instance.";
            public const string NoDuplicateTableNamesAllowed = "The table name entry already exists in the data matrix. Duplicate table names are not allowed.";
            public const string TemplateEditModeCloseWarning = "The screen is currently in edit mode. If you close now, you will lose any changes you've made. Sure you'd like to close?";
            public const string QueryDeletingDataSource = "Are you sure you'd like to delete the selected item(s).";
            public const string ExcelFileNotFound = "Xess could not find the original excel file source.";
            public const string CloneDataSourcePrompt = "Clone the selected data source?";

            public static string NoInputValueForMandatoryField(string fieldName)
            {
                return string.Format("A valid value for {0} must be entered in order to continue.", fieldName);
            }

            public static string QueryRemoveNonExistentFileFromRecentList(string fileName)
            {
                return string.Format("The file: {0}, does not exist. Would you like to remove it?", fileName);
            }

            public static string QueryDeletingTemplate(string templateTitle)
            {
                return string.Format("Are you sure you want to delete the Template titled: {0}? All sections will be deleted with it.", templateTitle);
            }

            public static string QueryDeletingTemplateSection(string templateSectionTitle)
            {
                return string.Format("Are you sure you want to delete the Template Section titled: {0}?", templateSectionTitle);
            }
        }

        public class StatusMessages
        {
            public const string DataRecordsGenerated = "Data records generated.";
            public const string DataRecordsNotGenerated = "Data records not generated.";
        }
    }
}
