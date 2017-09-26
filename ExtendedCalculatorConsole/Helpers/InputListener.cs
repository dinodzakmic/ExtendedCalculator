using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCalculatorConsole.Helpers
{
    internal static class InputListener
    {
        /// <summary>
        /// Helper method for listening user input
        /// </summary>
        /// <remarks>
        /// Reads the user input
        /// </remarks>
        internal static string Listen()
        {
            return Console.ReadLine()?.ToLowerInvariant();
        }
    }
}
