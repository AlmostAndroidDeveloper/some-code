using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLibrary
{
    public class Converter
    {
        private const string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Calculate(string number, int inputSystemNumber, int outputSystemNumber) 
            => FromDecimal(ToDecimal(number, inputSystemNumber), outputSystemNumber);

        private static string FromDecimal(string number, int outSystem)
        {
            var parsedNumber = int.Parse(number);
            var result = new StringBuilder();
            while (parsedNumber > 0)
            {
                result.Insert(0, DigitToChar(parsedNumber % outSystem));
                parsedNumber /= outSystem;
            }
            return result.ToString();
        }

        private static char DigitToChar(int digit) => alphabet[digit];

        private static string ToDecimal(string number, int inSystem)
        {
            int power = 0, sum = 0;
            for (int i = number.Length - 1; i >= 0; i--)
                sum += CharToDigit(number[i]) * (int)Math.Pow(inSystem, power++);
            return sum.ToString();
        }

        private static int CharToDigit(char symbol)
        {
            for (int i = 0; i < alphabet.Length; i++)
                if (alphabet[i].Equals(symbol))
                    return i;
            throw new ArgumentException();
        }       
    }
}
