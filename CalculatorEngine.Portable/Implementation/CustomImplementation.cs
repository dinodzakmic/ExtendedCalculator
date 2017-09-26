using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorEngine.Portable.Implementation
{
    internal class CustomImplementation
    {
        internal bool IsDisneyModeOn { get; set; }

        public CustomImplementation(bool isDisneyModeOn = false)
        {
            IsDisneyModeOn = isDisneyModeOn;
        }

        internal readonly string[] Operators = { "-", "+", "/", "*" };

        internal readonly Func<double, double, double>[] Operations =
        {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 * a2
        };

        /// <summary>
        /// Custom calculator implementation
        /// </summary>
        /// <remarks>
        /// Parses the expression  and provides the result
        /// </remarks>
        /// <param name="expression">
        /// Valid math expression
        /// </param>
        /// <param name="isDisneyModeOn">
        /// Extended calculator mode (disney or regular)
        /// </param>
        internal double Calculate(string expression, bool isDisneyModeOn = false)
        {
            try
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
                        while (operatorStack.Count > 0 && Array.IndexOf(Operators, token) <
                               Array.IndexOf(Operators, operatorStack.Peek()))
                        {
                            string op = operatorStack.Pop();
                            op = HandleMinus(operatorStack, op);
                            CalculateEach(operandStack, op);
                        }
                        operatorStack.Push(token);
                    }
                    else
                    {
                        operandStack.Push(isDisneyModeOn ? Math.Pow(double.Parse(token), 2) : double.Parse(token));
                    }
                    tokenIndex += 1;
                }

                while (operatorStack.Count > 0)
                {
                    var op = operatorStack.Pop();
                    op = HandleMinus(operatorStack, op);

                    CalculateEach(operandStack, op);
                }
                return operandStack.Pop();
            }
            catch 
            {
                throw new Exception("Please enter valid expression!");
            }
            
        }

        /// <summary>
        /// Calculate basic operations
        /// </summary>
        /// <remarks>
        /// Executes the operation
        /// </remarks>
        /// <param name="operandStack">
        /// Stack of operands 
        /// </param>
        /// <param name="op">
        /// Operation to be executed
        /// </param>
        private void CalculateEach(Stack<double> operandStack, string op)
        {
            double arg2 = operandStack.Pop();
            double arg1 = operandStack.Pop();
            operandStack.Push(Operations[Array.IndexOf(Operators, op)](arg1, arg2));
        }

        /// <summary>
        /// Minus operation handler
        /// </summary>
        /// <remarks>
        /// Handles the minus operations as well as the initial -/+
        /// </remarks>
        /// <param name="operatorStack">
        /// Stack of operators
        /// </param>
        /// <param name="op">
        /// First operation that needs to be executed
        /// </param>
        private static string HandleMinus(Stack<string> operatorStack, string op)
        {
            if (operatorStack.Count > 0)
            {
                var handleMinus = operatorStack.FirstOrDefault() == "-";

                if (handleMinus && op == "-")
                {
                    op = "+";
                    handleMinus = false;
                }

                if (handleMinus && op == "+")
                {
                    op = "-";
                    handleMinus = false;
                }
            }
            
            return op;
        }

        /// <summary>
        /// Token parser
        /// </summary>
        /// <remarks>
        /// Parses the string expression and creates the tokens stack (which consists of numbers and operations)
        /// </remarks>
        /// <param name="expression">
        /// Valid math expression
        /// </param>
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
            if (tokens.Any())
            {
                if (tokens.FirstOrDefault() == "-" || tokens.FirstOrDefault() == "+")
                {
                    tokens.Insert(0, "0");
                }
            }
            return tokens;
        }
    }
}
