using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace CalculatorEngine
{
    internal class PluginImplementation
    {
        internal PluginImplementation()
        {
        }

        internal double Calculate(string expression)
        {
            Expression formula = new Expression(expression);
            double result = formula.calculate();
            return result;
        }
    }
}
