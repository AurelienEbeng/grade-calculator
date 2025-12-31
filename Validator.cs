using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final
{
    internal class Validator
    {
        public bool Year(string text)
        {
            Regex validate = new Regex(@"^202\d$");
            if (validate.IsMatch(text))
            {
                return true;
            }
            return false;
        }

        public bool Session(string text)
        {
            Regex validate = new Regex(@"^([Ff]all|[Ww]inter|[Ss]ummer)$");
            if (validate.IsMatch(text))
            {
                return true;
            }
            return false;
        }
        public bool NumericGrade(string text)
        {
            Regex validate = new Regex(@"^100|(\d?\d)$");
            if (validate.IsMatch(text))
            {
                return true;
            }
            return false;
        }
    }
}
