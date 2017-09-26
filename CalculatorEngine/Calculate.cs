using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngine.Config;

namespace CalculatorEngine
{
    public class Calculate
    {
        public double CalculateResult(string expression, CalculationType calculationType)
        {
            var isCustomConfiguration = new Configuration(calculationType).IsCustomConfiguration();

            return isCustomConfiguration 
                ? new CustomImplementation().Calculate(expression) 
                : new PluginImplementation().Calculate(expression);
        }
    }
}
