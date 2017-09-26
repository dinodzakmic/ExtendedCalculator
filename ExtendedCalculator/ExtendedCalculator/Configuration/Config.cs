using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCalculator.Configuration
{
    internal class Config
    {
        /// <summary>
        /// Configuration properties
        /// </summary>
        /// <remarks>
        /// Handling configuration properties for the Extended Calculator.
        /// If it is true, custom extended calculator implementation is used. Otherwise, plugin implementation is used.
        /// </remarks>
        public static bool UseCustomImplementation = true;

        /// <summary>
        /// Configuration properties
        /// </summary>
        /// <remarks>
        /// Handling configuration properties for the Extended Calculator.
        /// IsDisneyModeOn is a boolean which is used in calculating methods, if the mode is not active, calculator operates in Regular Mode (e.g. 4*5=20), otherwise the calculator operates in Disney Mode (e.g. 4*5=400)
        /// </remarks>
        public static bool IsDisneyModeOn = false;
    }
}
