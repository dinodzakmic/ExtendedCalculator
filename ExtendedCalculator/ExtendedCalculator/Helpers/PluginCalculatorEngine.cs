using System;
using System.Text;
using CalculatorInterfaces;
using org.mariuszgromada.math.mxparser;

namespace ExtendedCalculator.Helpers
{
    public class PluginCalculatorEngine : ICalculatorEngine
    {
        internal bool IsDisneyModeOn { get; set; } = false;

        public PluginCalculatorEngine(bool isDisneyModeOn = false)
        {
            IsDisneyModeOn = isDisneyModeOn;
        }

        /// <summary>
        /// Helper method for plugin implementation
        /// </summary>
        /// <remarks>
        /// Parses expression formula, calls the calculate methods and provides the result
        /// </remarks>
        /// <param name="expression">
        /// Valid math expression
        /// </param>
        /// <param name="isDisneyModeOn">
        /// Extended calculator mode (disney or regular)
        /// </param>
        public double Calculate(string expression, bool isDisneyModeOn = false)
        {
            expression = expression.Replace('×', '*');
            expression = expression.Replace('÷', '/');
            Expression formula = new Expression(expression);
            if (!formula.checkSyntax())
                throw new Exception("Please enter valid expression!");

            if (isDisneyModeOn)
            {
                var stringBuilder = new StringBuilder();
                var tokens = formula.getCopyOfInitialTokens();
                foreach (var token in tokens)
                {
                    if (token.keyWord == "_num_")
                        token.tokenStr = Math.Pow(token.tokenValue, 2).ToString();

                    stringBuilder.Append(token.tokenStr);
                }

                formula.setExpressionString(stringBuilder.ToString());
            }
            
            var result = formula.calculate();
            return result;
        }
    }
}
