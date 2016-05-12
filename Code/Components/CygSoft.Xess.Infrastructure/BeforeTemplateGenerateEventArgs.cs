using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class BeforeTemplateGenerateEventArgs : EventArgs
    {
        public ITemplate Template { get; private set; }
        public string Text { get; private set; }
        public bool Cancel { get; set; }

        public BeforeTemplateGenerateEventArgs(ITemplate template)
        {
            this.Cancel = false;
            this.Template = template;
        }
    }
}
