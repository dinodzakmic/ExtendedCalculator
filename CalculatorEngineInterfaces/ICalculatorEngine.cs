using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterfaces
{
    public interface ICalculatorEngine
    {
        double Calculate(string expression, bool isDisneyModeOn = false);
    }
}
