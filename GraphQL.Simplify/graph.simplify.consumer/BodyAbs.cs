using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.simplify.consumer
{
    internal class BodyAbs : IBody
    {
        public string Name { get; private set; }
        public IQueryInfo QueryInfo { get; private set; }

        public List<IArgument> Arguments { get; private set; }

        public List<string> ResultFields { get; private set; }

        public List<Type> StringFormat { get; private set; }

        public IArgument AppendArgument(string name)
        {
            var argument = new ArgumentAbs(name);
            this.Arguments.Add(argument);

            return argument;
        }

        public BodyAbs(string name)
        {
            this.ResultFields = new List<string>();
            this.Arguments = new List<IArgument>();
            this.QueryInfo = new QueryInfoAbs();
            this.Name = name;

            this.StringFormat = new List<Type>() { 
                typeof(string)
            };
        }

        public override string ToString()
        {
            string body = "{@entity(queryInfo:{limit: @limit, page: @page}@arguments){@fieldList}}";
            string arguments = this.GetArguments();

            body = body.Replace("@entity", GetName(this.Name));
            body = body.Replace("@limit", this.QueryInfo.Limit.ToString());
            body = body.Replace("@page", this.QueryInfo.Page.ToString());
            body = body.Replace("@arguments", string.IsNullOrWhiteSpace(arguments)? string.Empty : $",{arguments}");
            body = body.Replace("@fieldList", string.Join(',', this.ResultFields.ToArray()));

            return body;
        }

        private string GetArguments()
        {
            const string argument = "@name:[@agumentList]";
            var result = new List<string>();

            foreach (var item in this.Arguments)
            {
                var argumentItem = argument;
                argumentItem = argumentItem.Replace("@name", GetName(item.Name));
                argumentItem = argumentItem.Replace("@agumentList", GetChecks(item));

                result.Add(argumentItem);
            }

            return string.Join(',', result.ToArray());
        }

        private string GetChecks(IArgument argument)
        {
            const string operation = "{operation: @operation, connector: @connector, value: @value}";
            var result = new List<string>();

            foreach (var item in argument.Checks)
            {
                var checkList = operation;

                checkList = checkList.Replace("@operation", item.Operation.ToString());
                checkList = checkList.Replace("@connector", item.Connector.ToString());
                checkList = checkList.Replace("@value", GetValue(item.Value));

                result.Add(checkList);
            }

            return string.Join(',', result.ToArray());
        }

        private string GetValue(object value)
        {
            if (this.StringFormat.Any(t => t == value.GetType()))
            {
                return $"\\\"{value}\\\"";
            }
            if (value.GetType() == typeof(DateTime))
            {
                var date = Convert.ToDateTime(value);
                return $"\\\"{date.ToString("yyyy-MM-dd HH:mm:ss")}\\\"";
            }
            else
            {
                return $"{value}";
            }
        }

        private string GetName(string name)
        {
            return name[0].ToString().ToLower() + name.Substring(1);
        }
    }
}
