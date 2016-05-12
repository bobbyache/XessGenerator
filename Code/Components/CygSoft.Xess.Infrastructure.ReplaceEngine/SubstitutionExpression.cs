
namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    public class SubstitutionExpression
    {
        public SubstitutionExpression(string outputPlaceholder, string actionIdentifier)
        {
            this.actionIdentifier = actionIdentifier;
            this.outputPlaceholder = outputPlaceholder;
        }

        public SubstitutionExpression(string outputPlaceholder, string actionIdentifier, string outputData)
        {
            this.outputData = outputData;
            this.actionIdentifier = actionIdentifier;
            this.outputPlaceholder = outputPlaceholder;
        }

        private string outputData = string.Empty;
        public string OutputData
        {
            // the data that replace the placeholder.
            get { return this.outputData; }
        }

        private string outputPlaceholder;
        public string OutputPlaceholder
        {
            // the actual placeholder like "@{[symbol]}"
            // @{depositId}
            get { return this.outputPlaceholder; }
        }

        private string actionIdentifier;
        public string ActionIdentifier
        {
            // the symbol text like "depositId".
            get { return this.actionIdentifier; }
        }
    }
}
