using System.Collections.Generic;

namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    internal class ReplaceActionSet
    {
        private string sourceIdentity;  // either a column id, a constant id... doesn't really matter.
        private SubstitutionMask substitutionMask;
        private Dictionary<string, ReplaceAction> replaceActionList = new Dictionary<string, ReplaceAction>();

        public ReplaceActionSet(string sourceIdentity, SubstitutionMask substitutionMask)
        {
            this.substitutionMask = substitutionMask;
            this.sourceIdentity = sourceIdentity;
        }

        public string SourceIdentity
        {
            get { return this.sourceIdentity; }
        }

        public void AddAction(string actionIdentity)
        {
            replaceActionList.Add(actionIdentity, new ReplaceAction(actionIdentity, this.substitutionMask));
        }


        public bool ActionExists(string actionIdentity)
        {
            return replaceActionList.ContainsKey(actionIdentity);
        }

        public void ClearActions()
        {
            replaceActionList.Clear();
        }

        public void AddActionTransform(string actionIdentity, ITransformFunction transformFunction)
        {
            if (replaceActionList.ContainsKey(actionIdentity))
                replaceActionList[actionIdentity].AddTransform(transformFunction);
        }

        public void ClearTransforms(string actionIdentity)
        {
            if (replaceActionList.ContainsKey(actionIdentity))
                replaceActionList[actionIdentity].ClearTransforms();
        }

        public List<SubstitutionExpression> GetSubstitutionPlaceHolders()
        {
            List<SubstitutionExpression> substitutionPlaceholderList = new List<SubstitutionExpression>();

            foreach (ReplaceAction replaceAction in replaceActionList.Values)
                substitutionPlaceholderList.Add(replaceAction.SubstitutionPlaceholder);

            return substitutionPlaceholderList;
        }

        public SubstitutionExpression[] CreateSubstitutions(string originalData)
        {
            List<SubstitutionExpression> expressionList = new List<SubstitutionExpression>();

            foreach (ReplaceAction action in replaceActionList.Values)
            {
                SubstitutionExpression expression = action.CreateSubstitution(originalData);
                expressionList.Add(expression);
            }
            return expressionList.ToArray();
        }
    }
}
