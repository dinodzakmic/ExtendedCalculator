using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine.Config
{
    internal class Configuration
    {

        internal CalculationType CalculationTypeProp { get; }
        internal Configuration(CalculationType calculationType)
        {
            CalculationTypeProp = calculationType;
        }

        internal bool IsCustomConfiguration()
        {
            return CalculationTypeProp == CalculationType.Custom;
        }
    }

    public enum CalculationType
    {
        Custom,
        Plugin
    }
}
