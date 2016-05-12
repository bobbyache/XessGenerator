using System;
using System.ComponentModel;

namespace CygSoft.Xess.Infrastructure
{
    public class PersistableObject
    {
        private Guid identifyingGuid;

        public PersistableObject()
        {
            this.identifyingGuid = Guid.NewGuid();
        }

        public PersistableObject(string guidString)
        {
            this.identifyingGuid = new Guid(guidString);
        }

        [Browsable(false)]
        public string Id
        {
            get { return this.identifyingGuid.ToString(); }
            set
            {
                this.identifyingGuid = new Guid(value);
            }
        }
    }
}
