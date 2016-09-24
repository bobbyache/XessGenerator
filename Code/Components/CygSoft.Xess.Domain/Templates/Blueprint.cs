
namespace CygSoft.Xess.Domain.Templates
{
    public class Blueprint
    {
        private string headerText = string.Empty;
        public string HeaderText
        {
            get { return this.headerText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.headerText = string.Empty;
                else
                    this.headerText = value;
            }
        }

        private string bodyText = string.Empty;
        public string BodyText
        {
            get { return this.bodyText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.bodyText = string.Empty;
                else
                    this.bodyText = value;
            }
        }

        private string footerText = string.Empty;
        public string FooterText
        {
            get { return this.footerText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.footerText = string.Empty;
                else
                    this.footerText = value;
            }
        }

        private string script = string.Empty;
        public string Script
        {
            get { return this.script; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.script = string.Empty;
                else
                    this.script = value;
            }
        }

    }
}
