using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
  public  class StringtoListSeperator
    {
        private char _Seperator;
        public StringtoListSeperator(char seperator)
        {
            _Seperator = seperator;
        }

        public List<int> SeperateToIntList(string numbers)
        {
            List<int> _numericList = new List<int>();

           if(isStringNotEmpty(numbers))
            {
                var _StringNumberList = numbers.Split(_Seperator);

                _numericList = StringArrayToInteger(_StringNumberList);
            }
            return _numericList;  
        }

        private List<int> StringArrayToInteger(string[] stringNumberList)
        {
           return stringNumberList.Select(x => int.Parse(x)).ToList();
        }

        private bool isStringNotEmpty(string numbers)
        {
            return !String.IsNullOrEmpty(numbers);
        }
    }
}
