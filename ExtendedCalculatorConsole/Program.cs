using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedCalculatorConsole.Configuration;
using ExtendedCalculatorConsole.Helpers;

namespace ExtendedCalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleOperations.ExtendedCalculator = new Calculator();
            Console.WriteLine("Welcome to the Extended Calculator!");
            Console.WriteLine("This calculator can be used in regular mode or disney mode, please choose initial mode.");

            ConsoleOperations.CalculateResult();
            ConsoleOperations.PostCalculate();

        }
    }
}
