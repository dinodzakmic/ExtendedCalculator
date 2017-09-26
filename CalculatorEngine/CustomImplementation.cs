using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    internal class CustomImplementation
    {
        internal readonly string[] Operators = { "-", "+", "/", "*" };

        internal readonly Func<double, double, double>[] Operations =
        {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 * a2
        };

        internal double Calculate(string expression)
        {
            var tokens = GetTokens(expression);
            var operandStack = new Stack<double>();
            var operatorStack = new Stack<string>();
            var tokenIndex = 0;

            while (tokenIndex < tokens.Count)
            {
                var token = tokens[tokenIndex];

                //If this is an operator  
                if (Array.IndexOf(Operators, token) >= 0)
                {
                    while (operatorStack.Count > 0 && Array.IndexOf(Operators, token) < Array.IndexOf(Operators, operatorStack.Peek()))
                    {
                        string op = operatorStack.Pop();
                        double arg2 = operandStack.Pop();
                        double arg1 = operandStack.Pop();
                        operandStack.Push(Operations[Array.IndexOf(Operators, op)](arg1, arg2));
                    }
                    operatorStack.Push(token);
                }
                else
                {
                    operandStack.Push(double.Parse(token));
                }
                tokenIndex += 1;
            }

            while (operatorStack.Count > 0)
            {
                var op = operatorStack.Pop();
                var arg2 = operandStack.Pop();
                var arg1 = operandStack.Pop();
                operandStack.Push(Operations[Array.IndexOf(Operators, op)](arg1, arg2));
            }
            return operandStack.Pop();
        }

        private List<string> GetTokens(string expression)
        {
            const string operators = "*/+-";
            var tokens = new List<string>();
            var sb = new StringBuilder();

            foreach (var c in expression.Replace(" ", string.Empty))
            {
                if (operators.IndexOf(c) >= 0)
                {
                    if ((sb.Length > 0))
                    {
                        tokens.Add(sb.ToString());
                        sb.Length = 0;
                    }
                    tokens.Add(c.ToString());
                }
                else
                {
                    sb.Append(c);
                }
            }

            if (sb.Length > 0)
            {
                tokens.Add(sb.ToString());
            }
            return tokens;
        }
    }
}
