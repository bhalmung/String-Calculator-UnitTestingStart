using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
    public class StringCalculator
    {
        private char _defaultSeperator = ',';
        public StringtoListSeperator _StringToListSeperatorObj;
        public StringSanitiser _SanitiserObject;
        public StringCalculator()
        {
            _StringToListSeperatorObj = new StringtoListSeperator(_defaultSeperator);
            _SanitiserObject = new String_Calculator.StringSanitiser(_defaultSeperator);
        }
        public int Add(string numbers)
        {
            var _result = 0;
            if (CheckforNotEmptyString(numbers))
            {
               var StrngAfterSanitise=  _SanitiserObject.Sanitise(numbers);

               var _ListIntOfNumbers= _StringToListSeperatorObj.SeperateToIntList(StrngAfterSanitise);

                _result = GetSumOfNumbers(_ListIntOfNumbers);
                //_retrun = int.Parse(numbers);
            }
            return _result;
        }

        public int GetSumOfNumbers(List<int> listNumbers)
        {
            ChecknegativeNumbers(listNumbers);
            listNumbers = RemoveLargeNumbers(listNumbers);
            return listNumbers.Sum();
        }

        private List<int> RemoveLargeNumbers(List<int> listNumbers)
        {
            return listNumbers.Where(x => x < 1000).ToList();
        }

        private void ChecknegativeNumbers(List<int> listNumbers)
        {
            var NegativeNumbers = listNumbers.Where(x => x < 0);
            if(NegativeNumbers.Count()>0)
            {
                throw new Exception(string.Join(",", NegativeNumbers));
            }
        }

        public bool CheckforNotEmptyString(string numbers)
        {
            return !string.IsNullOrEmpty(numbers);
        }
    }
}
