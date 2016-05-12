using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class AfterTemplateGenerateEventArgs : EventArgs
    {
        public ITemplate Template { get; private set; }
        public string Text { get; private set; }

        public AfterTemplateGenerateEventArgs(ITemplate template, string text)
        {
            this.Template = template;
            this.Text = text;
        }
    }
}
