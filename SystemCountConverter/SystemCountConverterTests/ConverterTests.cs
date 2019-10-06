using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterLibrary;
using System.Reflection;

namespace SystemCountConverterTests
{
    [TestClass]
    public class ConverterTests
    {
        Type ConverterToTest = typeof(Converter);

        [TestMethod]
        public void SimpleConvert()
        {
            Assert.AreEqual("351", Converter.Calculate("2401", 5, 10));
            Assert.AreEqual("3000321", Converter.Calculate("12345", 10, 4));
        }

        [TestMethod]
        public void ComplicatedConvert()
        {
            Assert.AreEqual("29A485", Converter.Calculate("AB725", 16, 12));
            Assert.AreEqual("702245", Converter.Calculate("AB725", 16, 10));
        }

        [TestMethod]
        public void FromDecimal()
        {
            var expectedNumbers = new string[] { "FFF" };
            var actualNumbers = new string[] { "4095" };
            var actualOutputSystemNumbers = new int[] { 16 };

            for (int i = 0; i < expectedNumbers.Length; i++)
                Assert.AreEqual(expectedNumbers[i], ConverterToTest.InvokeMember("FromDecimal",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic |
                    BindingFlags.Static, null, null,
                    new object[] { actualNumbers[i], actualOutputSystemNumbers[i] }));
        }

        [TestMethod]
        public void DigitToChar()
        {
            var expectedSymbols = new char[] { '0', 'F', 'Z' };
            var actualDigits = new int[] { 0, 15, 35 };

            for (int i = 0; i < expectedSymbols.Length; i++)
                Assert.AreEqual(expectedSymbols[i], ConverterToTest.InvokeMember("DigitToChar",
                BindingFlags.InvokeMethod | BindingFlags.NonPublic |
                BindingFlags.Static, null, null, new object[] { actualDigits[i] }));
        }

        [TestMethod]
        public void ToDecimal()
        {
            var expectedNumbers = new string[] { "6460" };
            var actualNumbers = new string[] { "201320" };
            var actualInputSystemNumbers = new int[] { 5 };

            for (int i = 0; i < expectedNumbers.Length; i++)
                Assert.AreEqual(expectedNumbers[i], ConverterToTest.InvokeMember("ToDecimal",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic |
                    BindingFlags.Static, null, null,
                    new object[] { actualNumbers[i], actualInputSystemNumbers[i] }));
        }

        [TestMethod]
        public void CharToDigit()
        {
            var expectedDigits = new int[] { 0, 15, 35 };
            var actualSymbols = new char[] { '0', 'F', 'Z' };

            for (int i = 0; i < expectedDigits.Length; i++)
                Assert.AreEqual(expectedDigits[i], ConverterToTest.InvokeMember("CharToDigit",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic |
                    BindingFlags.Static, null, null, new object[] { actualSymbols[i] }));
        }
    }
}
