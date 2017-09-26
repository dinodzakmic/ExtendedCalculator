using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedCalculatorConsole.Configuration;

namespace ExtendedCalculatorConsole.Helpers
{
    internal static class ConsoleOperations
    {
        internal static Calculator ExtendedCalculator { get; set; }
        internal static string[] TerminateStrings = { "q", "quit", "exit" };
        internal static string[] ProceedStrings = { "c", "continue", "calculate" };
        internal static string[] RevertStrings = {"clear", "undo"};

        /// <summary>
        /// Helper method for calculating the result
        /// </summary>
        /// <remarks>
        /// Reads the user input, calls the calculator engine for providing the result
        /// </remarks>
        /// <param name="currentExpression">
        /// Valid math expression which can be parsed and calculated.
        /// If the param is null, console is listening for the user input.
        /// If the param is a valid math expression, calculator is activated
        /// </param>
        internal static void CalculateResult(string currentExpression = null)
        {
            if (currentExpression == null)
            {
                SetMode();
                Console.WriteLine("Enter valid math expression, e.g. 2+3*4");
                currentExpression = InputListener.Listen();
            }

            ExtendedCalculator.EnteredFullExpression(currentExpression);

            try
            {
                Console.WriteLine("Result: {0}\n", ExtendedCalculator.CurrentResult);
                PostCalculate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Helper method for setting the calculator mode
        /// </summary>
        /// <remarks>
        /// Reads the user input and sets the calculator mode (regular or disney)
        /// </remarks>
        internal static void SetMode()
        {
            Console.WriteLine("Press R for regular mode or D for disney mode. You can change the mode before entering math expression in the same way");

            var mode = Helpers.InputListener.Listen();

            if (mode == "r")
                Config.IsDisneyModeOn = false;
            else if (mode == "d")
                Config.IsDisneyModeOn = true;
            else
                SetMode();
        }

        /// <summary>
        /// Helper method for handling post calculate options (terminate, continue or clear/undo)
        /// </summary>
        /// <remarks>
        /// Reads the user input and handles the calculator behaviour
        /// </remarks>
        internal static void PostCalculate()
        {
            Console.WriteLine("Type q | quit | exit to terminate or c | continue | calculate to proceed with using Extended Calculator");
            Console.WriteLine("Or type clear | undo to clear the result and console window or undo the last operation, respectively.");

            var userInput = Helpers.InputListener.Listen();

            if (TerminateStrings.Any(t => t.Equals(userInput)))
                Environment.Exit(0);
            else if (ProceedStrings.Any(p => p.Equals(userInput)))
                CalculateResult();
            else if (RevertStrings.Any(rs => rs.Equals(userInput)))
            {
                if (userInput == "clear")
                {
                    ExtendedCalculator.Clear();
                    Console.Clear();
                    CalculateResult();
                }
                else
                {
                    ExtendedCalculator.Undo();
                    CalculateResult(ExtendedCalculator.CurrentText);
                }
            }
            else
                PostCalculate();
        }
    }
}
