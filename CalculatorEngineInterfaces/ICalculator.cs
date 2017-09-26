using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterfaces
{
    public interface ICalculator
    {
        void EnteredNumber(string number);
        void EnteredOperator(string operand);
        void Undo();
        void Clear();
        double Calculate(string expression);
        void EnteredFullExpression(string expression);
    }
}
