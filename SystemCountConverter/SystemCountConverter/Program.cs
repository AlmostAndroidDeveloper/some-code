using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterLibrary;

namespace SystemCountConverter
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(Converter.Calculate(
                Console.ReadLine(), 
                int.Parse(Console.ReadLine()), 
                int.Parse(Console.ReadLine())));
            Console.ReadKey();
        }
    }
}
