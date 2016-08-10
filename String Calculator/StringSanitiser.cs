using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
   public class StringSanitiser
    {
        public char _DefaultSeperator;
        public StringSanitiser(char defaultSeperator)
        {
            _DefaultSeperator = defaultSeperator;
        }

        public string GetDefaultSeperator(string number,out string newNumber )
        {
            newNumber = number;
            string _resut=_DefaultSeperator.ToString();
            if(doesStringHaveDifferentSeperator(number))
            {
                newNumber = number.Remove(0, 2);
                var splitNumber = newNumber.Split(new Char[] {'\n'}, 2);
                newNumber = splitNumber.Last();
                _resut =  splitNumber.First() ;
                _resut = ChangeForMultipleSeperators(_resut);
            
            }
            return _resut;
        }

        private string ChangeForMultipleSeperators(string  resut)
        {
            resut = resut.Replace("][", ",");
            resut = resut.Replace("[", "");
            resut = resut.Replace("]", "");
            return resut;
        }

        private bool doesStringHaveDifferentSeperator(string number)
        {
            return number.StartsWith("//");
        }
        string ReplaceMultipleSeperatorWithDefaultSeperator(string numbers,string seperators)
        {
            var _seperatorsSplit = seperators.Split(',');
            foreach (var seperator in _seperatorsSplit)
            {
                if (!String.IsNullOrEmpty(seperator))
                {
                    numbers = numbers.Replace(seperator, _DefaultSeperator.ToString());
                }
            }
            return numbers;
        }
        public string Sanitise(string numbers)
        {
            string newNumber;
            var seperator = GetDefaultSeperator(numbers, out newNumber);
            newNumber= newNumber.Replace('\n',  _DefaultSeperator);
            return ReplaceMultipleSeperatorWithDefaultSeperator(newNumber, seperator);

        }
    }
}
