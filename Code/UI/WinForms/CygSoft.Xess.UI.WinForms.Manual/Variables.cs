using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace CygSoft.Xess.UI.WinForms
{
    public class Variables
    {
        private Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

        public string[] Placeholders
        {
            get { return variables.Values.Select(r => r.Placeholder).ToArray(); }
        }

        public string[] Columns
        {
            get { return variables.Values.Select(r => r.Name).ToArray(); }
        }

        public Variable[] VariableList
        {
            get { return variables.Values.ToArray(); }
        }

        public Variable this[string columnName]
        {
            get
            {
                if (variables.ContainsKey(columnName))
                    return variables[columnName];
                else
                    return null;
            }
        }

        public void Update(string blueprintText)
        {
            Regex regx = new Regex(@"@{.*?}");
            MatchCollection matches = regx.Matches(blueprintText);
            variables.Clear();

            foreach (Match match in matches)
            {
                Variable variable = new Variable(match.Value);
                if (!variables.ContainsKey(variable.Name))
                    variables.Add(variable.Name, variable);
            }
        }
    }
}
