using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixCalc;
namespace Matrix_should
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Plus()
        {
            var first = new Matrix { Values = new int[2, 2] { { 1, 1 }, { 1, 1 } }, Width = 2, Height = 2 };
            var second = new Matrix { Values = new int[2, 2] { { 1, 1 }, { 1, 1 } }, Width = 2, Height = 2 };
            var plusResult = new Matrix { Values = new int[2, 2] { { 2, 2 }, { 2, 2 } }, Width = 2, Height = 2 };

            first.Plus(second);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Assert.AreEqual(plusResult.Values[i, j], first.Values[i, j]);
            first.Minus(second);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Assert.AreEqual(second.Values[i, j], first.Values[i, j]);
        }

        [TestMethod]
        public void Minus()
        {
            var first = new Matrix { Values = new int[2, 2] { { 1, 1 }, { 1, 1 } }, Width = 2, Height = 2 };
            var second = new Matrix { Values = new int[2, 2] { { 1, 1 }, { 1, 1 } }, Width = 2, Height = 2 };
            var minusResult = new Matrix { Values = new int[2, 2] { { 0, 0 }, { 0, 0 } }, Width = 2, Height = 2 };

            first.Minus(second);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Assert.AreEqual(minusResult.Values[i, j], first.Values[i, j]);
        }

        [TestMethod]
        public void SimpleMultiply()
        {
            var first = new Matrix { Values = new int[3, 3] { { 2, 4, 5 }, { 5, 3, 2 }, { 6, 2, 3 } }, Width = 3, Height = 3 };
            var second = new Matrix { Values = new int[3, 3] { { 5, 8, 9 }, { 9, 4, 1 }, { 5, 4, 2 } }, Width = 3, Height = 3 };
            var result = new Matrix { Values = new int[3, 3] { { 71, 52, 32 }, { 62, 60, 52 }, { 63, 68, 62 } }, Width = 3, Height = 3 };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(result.Values[i, j], Matrix.Multiply(first, second).Values[i, j]);
        }

        [TestMethod]
        public void DifferentSizesMultiply()
        {
            var first = new Matrix { Values = new int[3, 4] { { 2, 4, 5, 9 }, { 5, 3, 2, 5 }, { 6, 2, 3, 4 } }, Width = 4, Height = 3 };
            var second = new Matrix { Values = new int[4, 3] { { 5, 8, 9 }, { 9, 4, 1 }, { 5, 4, 2 }, { 3, 2, 1 } }, Width = 3, Height = 4 };
            var firstResult = new Matrix
            {
                Values = new int[3, 3] { { 98, 70, 41 }, { 77, 70, 57 }, { 75, 76, 66 } },
                Width = 3,
                Height = 3
            };
            var secondResult = new Matrix
            {
                Values = new int[4, 4] { { 104, 62, 68, 121 }, { 44,50,56,105},
            {42,36,39,73 },{22,20,22,41}},
                Width = 4,
                Height = 4
            };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(firstResult.Values[i, j], Matrix.Multiply(first, second).Values[i, j]);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Assert.AreEqual(secondResult.Values[i, j], Matrix.Multiply(second, first).Values[i, j]);

        }

        [TestMethod]
        public void MultiplyOneNumberTest()
        {
            var first = new Matrix { Values = new int[3, 4] { { 2, 4, 5, 9 }, { 5, 3, 2, 5 }, { 6, 2, 3, 4 } }, Width = 4, Height = 3 };
            var second = new Matrix { Values = new int[4, 3] { { 5, 8, 9 }, { 9, 4, 1 }, { 5, 4, 2 }, { 3, 2, 1 } }, Width = 3, Height = 4 };

            Assert.AreEqual(56, Matrix.MultiplyOneElement(second, first, 1, 2));
        }

        [TestMethod]
        public void FindPositiveDiagonal()
        {
            var matrix = new Matrix { Values = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, Width = 3, Height = 3 };
            Assert.AreEqual(45, Matrix.CountOnePositiveDiagonal(matrix, 0));
            Assert.AreEqual(84, Matrix.CountOnePositiveDiagonal(matrix, 1));
            Assert.AreEqual(96, Matrix.CountOnePositiveDiagonal(matrix, 2));
        }

        [TestMethod]
        public void FindNegativeDiagonal()
        {
            var matrix = new Matrix { Values = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, Width = 3, Height = 3 };
            Assert.AreEqual(48, Matrix.CountOneNegativeDiagonal(matrix, 0));
            Assert.AreEqual(72, Matrix.CountOneNegativeDiagonal(matrix, 1));
            Assert.AreEqual(105, Matrix.CountOneNegativeDiagonal(matrix, 2));
        }

        [TestMethod]
        public void FindDeterminant()
        {
            var matrix = new Matrix { Values = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, Width = 3, Height = 3 };
            Assert.AreEqual(0, Matrix.FindDeterminant(matrix));
        }
    }
}
