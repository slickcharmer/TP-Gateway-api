using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validation
    {
        public static string IsValidBP(string str)
        {

            string pattern = @"^\d{1,3}\/\d{1,3}$";
            if (!Regex.IsMatch(str, pattern))
            {
                throw new Exception("Bp is not correct");
            }
            else
            {
                return str;
            }
        }
    }
}
