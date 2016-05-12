
namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    public class SubstitutionMask
    {
        private string prefix;
        public string Prefix { get { return this.prefix; } }
        private string postfix;
        public string Postfix { get { return this.postfix; } }

        public string ActionIdentity
        {
            get;
            set;
        }

        public SubstitutionMask(string prefix, string postfix)
        {
            this.prefix = prefix;
            this.postfix = postfix;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", this.prefix, this.ActionIdentity, this.postfix);
        }
    }
}
