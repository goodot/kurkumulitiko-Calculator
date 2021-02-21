using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Test]
        [TestCase("5+17/15", 6.13333)]
        [TestCase("(12.56 - 6.25)*7/(8+3)", 4.01545)]
        public void CalculateExpression(string expression, decimal expectedValue)
        {
            var result = Calculator.Calculate(expression);
            result = Math.Round(result, 5);
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}