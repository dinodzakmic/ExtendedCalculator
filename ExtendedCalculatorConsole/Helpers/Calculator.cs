using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngine.Portable.Implementation;
using CalculatorInterfaces;
using ExtendedCalculatorConsole.Configuration;

namespace ExtendedCalculatorConsole.Helpers
{
    public class Calculator : ICalculator
    {
        public string CurrentText { get; set; } = String.Empty;
        public double CurrentResult { get; set; } = 0;
        public bool OperationsAvailable { get; set; } = false;

        protected ICalculatorEngine CalculatorEngine;
        public Calculator()
        {
            CalculatorEngine = new CustomCalculatorEngine() as ICalculatorEngine;
        }

        /// <summary>
        /// Implementation method within ICalculator interface
        /// </summary>
        /// <remarks>
        /// This method is not implemented for console applications 
        /// </remarks>
        public void EnteredNumber(string number)
        {
            throw new Exception("I implemented Console extended calculator in regular mode! Operations are handled and calculated as the user press enter!");
        }
        /// <summary>
        /// Implementation method within ICalculator interface
        /// </summary>
        /// <remarks>
        /// This method is not implemented for console applications 
        /// </remarks>

        public void EnteredOperator(string operand)
        {
            throw new Exception("I implemented Console extended calculator in regular mode! Operations are handled and calculated as the user press enter!");
        }

        /// <summary>
        /// Implementation method within ICalculator interface
        /// </summary>
        /// <remarks>
        /// Handling undo operation for the ExtendedCalculator.
        /// Reverts the last valid operation and calculate the result
        /// </remarks>

        public void Undo()
        {
            if (CurrentText.Length == 0)
            {
                CurrentResult = 0;
                OperationsAvailable = false;
                return;
            };

            var lastCharacter = CurrentText[CurrentText.Length - 1].ToString();
            var matchOperand = lastCharacter.IndexOfAny("*/+-".ToCharArray()) != -1;
            while (!matchOperand)
            {
                CurrentText = CurrentText.Remove(CurrentText.Length - 1);
                if (CurrentText.Length == 0) break;
                lastCharacter = CurrentText[CurrentText.Length - 1].ToString();
                matchOperand = lastCharacter.IndexOfAny("*/+-".ToCharArray()) != -1;
            }

            if (CurrentText.Length == 0)
            {
                CurrentResult = 0;
                OperationsAvailable = false;
                return;
            }

            CurrentText = CurrentText.Remove(CurrentText.Length - 1);
            CurrentResult = Calculate(CurrentText);
            OperationsAvailable = true;
        }

        /// <summary>
        /// Implementation method within ICalculator interface
        /// </summary>
        /// <remarks>
        /// Handling clear operation for the ExtendedCalculator
        /// Clears the console window and all calculator operations
        /// </remarks>
        public void Clear()
        {
            CurrentText = string.Empty;
            CurrentResult = 0;
            OperationsAvailable = false;
        }

        /// <summary>
        /// Helper method within Calculator class
        /// </summary>
        /// <remarks>
        /// Handling calculate operation for the ExtendedCalculator.
        /// Calculates the result of the entered math expression
        /// </remarks>
        /// <param name="expression">
        /// Valid math expression which can be parsed and calculated
        /// </param>
        /// <returns>
        /// Double value after calculating the result
        /// </returns>
        public double Calculate(string expression)
        {
            try
            {
                return CalculatorEngine.Calculate(expression, Config.IsDisneyModeOn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                CurrentText = string.Empty;
                return double.NaN;
            }
        }

        /// <summary>
        /// Implementation method within ICalculator interface
        /// </summary>
        /// <remarks>
        /// Handling entered expression.
        /// Sets the text, calls the calculate method and sets the result
        /// </remarks>
        /// <param name="expression">
        /// Valid math expression which can be parsed and calculated
        /// </param>
        public void EnteredFullExpression(string expression)
        {
            CurrentText = expression;
            CurrentResult = Calculate(expression);
        }
    }
}
