using CalculatorInterfaces;

namespace CalculatorEngine.Portable.Implementation
{
    public class CustomCalculatorEngine : ICalculatorEngine
    {
        internal CustomImplementation CustomImplementation { get; set; }
        public CustomCalculatorEngine()
        {
            CustomImplementation = new CustomImplementation();
        }

        /// <summary>
        /// Helper method for custom calculator implementation
        /// </summary>
        /// <remarks>
        /// Parses the expression, calls the calculate method and provides the result
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
            return CustomImplementation.Calculate(expression, isDisneyModeOn);
        }
    }
}
