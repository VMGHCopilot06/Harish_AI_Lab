using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sample_Console
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestIsPrime_WithPrimeNumber()
        {
            // Arrange
            int number = 5;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsPrime_WithNonPrimeNumber()
        {
            // Arrange
            int number = 4;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrime_WithNegativeNumber()
        {
            // Arrange
            int number = -1;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrime_WithZero()
        {
            // Arrange
            int number = 0;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrime_WithOne()
        {
            // Arrange
            int number = 1;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrime_WithTwo()
        {
            // Arrange
            int number = 2;

            // Act
            bool result = Program.IsPrime(number);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
