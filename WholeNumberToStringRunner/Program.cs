using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeNumberToStringConverter;

namespace WholeNumberToStringRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to exit");
            do
            {
                while (!Console.KeyAvailable)
                {
                    string data = string.Empty;
                    try
                    {
                        Console.WriteLine("Press enter a valid whole Number ");
                        data = Console.ReadLine();
                        Console.WriteLine("Converted String is : " + NumberToStringConverter.ConvertNumberToReadableString(data));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input : " + data + ", try again..!");
                    }
                    ;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
