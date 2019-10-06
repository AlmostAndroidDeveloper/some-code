using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //var matrix = new Matrix();
            var first = new Matrix();
            var second = new Matrix();
            first.Input();
            second.Input();
            Matrix.Multiply(first, second).Print();
            Console.ReadKey();
        }
    }
}
