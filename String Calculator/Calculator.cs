using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
   public class Calculator
    {
        public IConsole _Console;
        public StringCalculator _StringCalculator;
        public Calculator(IConsole console,StringCalculator stringCalculator)
        {
            _Console = console;
            _StringCalculator = stringCalculator;
        }

        public void Calculate()
        {
            var numberString = _Console.ReadLine();
            _Console.Write($"Result is : {_StringCalculator.Add(numberString)}");
        }
    }
}
