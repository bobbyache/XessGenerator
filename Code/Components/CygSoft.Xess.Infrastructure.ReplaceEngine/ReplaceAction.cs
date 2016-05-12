using System.Collections.Generic;

namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    internal class ReplaceAction
    {
        private SubstitutionMask substitutionMask;
        private List<ITransformFunction> transFormFunctionList = new List<ITransformFunction>();

        public ReplaceAction(string actionIdentity, SubstitutionMask substitutionMask)
        {
            this.substitutionMask = new SubstitutionMask(substitutionMask.Prefix, substitutionMask.Postfix);
            this.substitutionMask.ActionIdentity = actionIdentity;
        }

        public string ActionIdentity
        {
            get { return this.substitutionMask.ActionIdentity; }
        }

        public SubstitutionExpression SubstitutionPlaceholder
        {
            get { return new SubstitutionExpression(this.substitutionMask.ToString(), this.substitutionMask.ActionIdentity); }
        }

        public void AddTransform(ITransformFunction transformFunction)
        {
            transFormFunctionList.Add(transformFunction);
        }

        public void ClearTransforms()
        {
            transFormFunctionList.Clear();
        }

        public SubstitutionExpression CreateSubstitution(string originalData)
        {
            string origData = originalData;

            foreach (ITransformFunction function in transFormFunctionList)
            {
                function.OriginalData = origData;
                origData = function.Transform();
            }

            SubstitutionExpression exp = new SubstitutionExpression(substitutionMask.ToString(), substitutionMask.ActionIdentity, origData);
            return exp;
        }
    }
}
