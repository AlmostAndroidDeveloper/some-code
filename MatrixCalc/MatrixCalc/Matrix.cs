using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalc
{
    public class Matrix
    {
        public int Width;
        public int Height;
        public int[,] Values;

        public void Plus(Matrix matrixToPlus)
        {
            if (Width == matrixToPlus.Width && Height == matrixToPlus.Height)
                for (int y = 0; y < Values.GetLength(0); y++)
                    for (int x = 0; x < Values.GetLength(1); x++)
                        Values[y, x] += matrixToPlus.Values[y, x];
            else Console.WriteLine("Error. Type equal-sized matrixes");
        }

        public void Minus(Matrix matrixToMinus)
        {
            if (Width == matrixToMinus.Width && Height == matrixToMinus.Height)
                for (int y = 0; y < Values.GetLength(0); y++)
                    for (int x = 0; x < Values.GetLength(1); x++)
                        Values[y, x] -= matrixToMinus.Values[y, x];
            else Console.WriteLine("Error. Type equal-sized matrixes");
        }

        public static Func<Matrix, Matrix, Matrix> Multiply = (first, second) =>
          {
              if (second.Width != first.Height || second.Height != first.Width) return null;
              var result = new Matrix
              {
                  Width = first.Height,
                  Height = second.Width,
                  Values = new int[first.Height, second.Width]
              };
              if (second.Width == first.Height && second.Height == first.Width)
                  for (int y = 0; y < result.Values.GetLength(0); y++)
                      for (int x = 0; x < result.Values.GetLength(1); x++)
                          result.Values[y, x] = MultiplyOneElement(first, second, y, x);
              return result;
          };

        public static Func<Matrix, Matrix, int, int, int> MultiplyOneElement = (first, second, yPos, xPos) => {
            int result = 0;
            for (int x = 0; x < first.Values.GetLength(1); x++)
                result += first.Values[yPos, x] * second.Values[x, xPos];
            return result;
        };

        public static Func<Matrix,int> FindDeterminant = (m) =>
        {
            int result = 0;
            for (int x = 0; x < m.Width; x++)
                result += CountOnePositiveDiagonal(m, x);
            for (int x = 0; x < m.Width; x++)
                result -= CountOneNegativeDiagonal(m, x);
            return result;
        };

        public static Func<Matrix, int, int> CountOneNegativeDiagonal = (m, x) =>
          {
              int result = 1;
              for (int y = 0; y < m.Height; y++)
              {
                  result *= m.Values[y, x];
                  x--;
                  if (x < 0) x = m.Width - 1;
              }
              return result;
          };

        public static Func<Matrix, int, int> CountOnePositiveDiagonal = (m, x) =>
        {
            int result = 1;
            for (int y = 0; y < m.Height; y++)
            {
                result *= m.Values[y, x];
                x++;
                if (x == m.Width) x = 0;
            }
            return result;
        };

        public static Matrix FindReverseMatrix(Matrix matrix) // допили это
        {
            var result = new Matrix { Values = new int[matrix.Height, matrix.Width], Width = matrix.Width, Height = matrix.Height };
            return result;
        }

        public void Print()
        {
            for (int y = 0; y < Values.GetLength(0); y++)
            {
                for (int x = 0; x < Values.GetLength(1); x++)
                    Console.Write(Values[y, x].ToString() + " ");
                Console.WriteLine("\n");
            }

        }

        public void Input()
        {
            Console.WriteLine("Enter width:");
            int width = int.Parse(Console.ReadLine());
            Width = width;
            Console.WriteLine("Enter height:");
            int height = int.Parse(Console.ReadLine());
            Height = height;

            Values = new int[height, width];

            Console.WriteLine("Type your matrix here, dividing numbers by space");
            for (int y = 0; y < height; y++)
            {
                var rowSplit = Console.ReadLine().Split(' ');
                for (int x = 0; x < width; x++)
                    Values[y, x] = int.Parse(rowSplit[x]);
            }
            Console.WriteLine("");
        }
    }
}
