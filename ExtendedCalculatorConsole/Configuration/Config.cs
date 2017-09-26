using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCalculatorConsole.Configuration
{

    internal class Config
    {
        /// <summary>
        /// Configuration properties
        /// </summary>
        /// <remarks>
        /// Handling configuration properties for the Extended Calculator.
        /// IsDisneyModeOn is a boolean which is used in calculating methods, if the mode is not active, calculator operates in Regular Mode (e.g. 4*5=20), otherwise the calculator operates in Disney Mode (e.g. 4*5=400)
        /// </remarks>
        internal static bool IsDisneyModeOn { get; set; } = false;
    }
}
