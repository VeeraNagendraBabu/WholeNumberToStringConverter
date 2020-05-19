using System;
using System.Collections.Generic;
using System.Text;

namespace WholeNumberToStringConverter
{
    public static class NumberToStringConverter
    {
        public static bool IsInputAValidOne(string input)
        {
            long inputD;
            if (Int64.TryParse(input, out inputD))
            {
                if (inputD >= 0 && inputD < float.MaxValue)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} not a whole Number", input));
            }
        }
        public static string ConvertNumberToString(string input)
        {
            string result = string.Empty;
            result = ConvertSingleDigitToString(input);
            return result.Trim();
        }
        private static String ConvertSingleDigitToString(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            {
                switch (_Number)
                {
                    case 0: return "Zero";
                    case 1: return "One";
                    case 2: return "Two";
                    case 3: return "Three";
                    case 4: return "Four";
                    case 5: return "Five";
                    case 6: return "Six";
                    case 7: return "Seven";
                    case 8: return "Eight";
                    case 9: return "Nine";
                    default:
                        throw new IndexOutOfRangeException(String.Format("{0} not a digit", _Number));
                }
            }
        }

    }
}
