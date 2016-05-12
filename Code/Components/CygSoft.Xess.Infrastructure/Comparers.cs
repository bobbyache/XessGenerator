using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class TemplateTitleComparer : IComparer<ITemplate>
    {
        public int Compare(ITemplate x, ITemplate y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }

    public class TemplateListItemTitleComparer : IComparer<TemplateListItem>
    {
        public int Compare(TemplateListItem x, TemplateListItem y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
