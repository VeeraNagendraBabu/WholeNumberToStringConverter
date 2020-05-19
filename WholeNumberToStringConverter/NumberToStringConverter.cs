using System;

namespace WholeNumberToStringConverter
{
    public static class NumberToStringConverter
    {
        public static string ConvertNumberToReadableString(string input)
        {
            if (IsInputAValidOne(input))
            {
                if (input.Length == 1 && input == "0")
                {
                    return "Zero";
                }
                return ConvertNumberToString(input);
            }
            return string.Empty;
        }
        public static bool IsInputAValidOne(string input)
        {
            long inputD;
            if (Int64.TryParse(input, out inputD))
            {
                if (inputD >= 0 && inputD < float.MaxValue)
                    return true;
                else
                    throw new ArgumentException(String.Format("{0} not a whole Number", input));
            }
            else
            {
                throw new ArgumentException(String.Format("{0} not a whole Number", input));
            }
        }
        public static string ConvertNumberToString(string input)
        {
            string result = string.Empty;
            bool isCompleted = false;
            if (IsInputAValidOne(input))
            {
                int index = 0;
                int numberLength = input.Length;
                String head = "";
                switch (numberLength)
                {
                    case 1:
                        result = ConvertSingleDigitToString(input);
                        isCompleted = true;
                        break;
                    case 2:
                        result = ConvertDoubleDigitToString(input);
                        isCompleted = true;
                        break;
                    case 3:
                        index = (numberLength % 3) + 1;
                        head = " Hundred ";
                        break;
                    case 4:
                        index = (numberLength % 4) + 1;
                        head = " Thousand ";
                        break;
                }
                if (!isCompleted)
                {
                    if (input.Substring(0, index) != "0" && input.Substring(index) != "0")
                    {
                        try
                        {
                            result = ConvertNumberToString(input.Substring(0, index)) + head + ConvertNumberToString(input.Substring(index));
                        }
                        catch { }
                    }
                    else
                    {
                        result = ConvertNumberToString(input.Substring(0, index)) + ConvertNumberToString(input.Substring(index));
                    }
                }
            }
            return result.Trim();
        }

        private static String ConvertSingleDigitToString(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            {
                switch (_Number)
                {
                    case 0: return "";
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
        private static String ConvertDoubleDigitToString(String Number)
        {

            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
                case 20: return "Twenty";
                case 30: return "Thirty";
                case 40: return "Fourty";
                case 50: return "Fifty";
                case 60: return "Sixty";
                case 70: return "Seventy";
                case 80: return "Eighty";
                case 90: return "Ninty";
                default:
                    if (_Number > 0)
                    {
                        name = ConvertDoubleDigitToString(Number.Substring(0, 1) + "0") + " " + ConvertSingleDigitToString(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

    }
}
    