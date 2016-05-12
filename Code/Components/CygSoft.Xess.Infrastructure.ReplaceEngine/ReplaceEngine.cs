using System;
using System.Collections.Generic;
using System.Data;

namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    public class ReplaceEngine
    {
        private SubstitutionMask substitutionMask;
        private Dictionary<string, ReplaceActionSet> replacementActionSets = new Dictionary<string, ReplaceActionSet>();

        public ReplaceEngine(SubstitutionMask substitutionMask)
        {
            this.substitutionMask = substitutionMask;
        }

        public void GenerateDefaultActions(string[] defaultIdentifierList)
        {
            ClearActions();
            foreach (string defaultIdentifier in defaultIdentifierList)
                AddAction(defaultIdentifier, defaultIdentifier);
        }

        public void GenerateDefaultActions(DataTable dataTable)
        {
            ClearActions();
            // should add an action set for each column.
            foreach (DataColumn column in dataTable.Columns)
                AddAction(column.ColumnName, column.ColumnName);
        }

        public void AddAction(string sourceIdentity, string actionIdentity)
        {
            if (!replacementActionSets.ContainsKey(sourceIdentity))
            {
                ReplaceActionSet replaceActionSet = new ReplaceActionSet(sourceIdentity, this.substitutionMask);
                replacementActionSets.Add(sourceIdentity, replaceActionSet);
            }
            replacementActionSets[sourceIdentity].AddAction(actionIdentity);
        }

        public void AddActionTransform(string actionIdentity, ITransformFunction transformFunction)
        {
            foreach (ReplaceActionSet replaceActionSet in replacementActionSets.Values)
            {
                if (replaceActionSet.ActionExists(actionIdentity))
                {
                    //replaceActionSet.SourceIdentity
                    replaceActionSet.AddActionTransform(actionIdentity, transformFunction);
                    break;
                }
            }
        }

        public void ClearTransforms()
        {
            throw new NotImplementedException();
        }

        public void ClearActions()
        {
            replacementActionSets.Clear();
            //throw new NotImplementedException();
        }

        public SubstitutionExpression[] GetSubstitutionPlaceholders()
        {
            List<SubstitutionExpression> substitutionPlaceholderList = new List<SubstitutionExpression>();

            foreach (ReplaceActionSet actionSet in replacementActionSets.Values)
                substitutionPlaceholderList.AddRange(actionSet.GetSubstitutionPlaceHolders());

            return substitutionPlaceholderList.ToArray();
        }

        public SubstitutionExpression[] CreateSubstitutions(string sourceIdentity, string originalData)
        {
            ReplaceActionSet actionSet = replacementActionSets[sourceIdentity];
            return actionSet.CreateSubstitutions(originalData);
        }
    }


}
