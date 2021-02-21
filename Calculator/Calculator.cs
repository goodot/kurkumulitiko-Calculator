using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculator
{
    public static class Calculator
    {
        public static decimal Calculate(string s)
        {
            s = s.Replace(" ", string.Empty);
            List<string> operators = new List<string>();
            List<string> numbers = new List<string>();
            while (s.IndexOf(")") > 0)
            {
                Parentheses(ref s);
                while (s.IndexOf("--") > 0)
                {
                    s = s.Replace("--", "+");
                }
            }
            while (s.Length > 0)
            {
                numbers.Add(ReadNextNumber(ref s));
                if (s.Length > 0)
                    operators.Add(ReadNextOperator(ref s));
            }
            MultiplicationAndDivision(operators, numbers);
            AdditionAndSubtraction(operators, numbers);
            return decimal.Parse(numbers[0]);
        }

        private static void Parentheses(ref string s)
        {
            var right = s.IndexOf(")");
            if (right <= 0) return;
            var left = s.Substring(0, right).LastIndexOf("(");

            var subs = s.Substring(left + 1, right - left - 1);
            s = s.Substring(0, left) + Calculate(subs) + s.Substring(right + 1);
        }

        private static string ReadNextOperator(ref string s)
        {
            var @operator = s.Substring(0, 1);
            s = s.Substring(1);
            return @operator;
        }

        private static string ReadNextNumber(ref string s)
        {
            var number = s.Substring(0, 1);
            for (var i = 1; i < s.Length; i++)
            {
                var letter = s[i];
                if (letter != '+' && letter != '-' && letter != '*' && letter != '/')
                    number += letter;
                else
                    break;
            }
            s = s.Substring(number.Length);
            return number;
        }

        private static void MultiplicationAndDivision(List<string> operators, List<string> numbers)
        {
            for (var i = 0; i < operators.Count; i++)
            {
                if (operators[i] != "*" && operators[i] != "/") continue;
                var @operator = operators[i];
                operators.Remove(operators[i]);
                var number1 = numbers[i];
                var number2 = numbers[i + 1];
                numbers.Remove(number1);
                numbers.Remove(number2);
                var item = @operator == "*" ? decimal.Parse(number1) * decimal.Parse(number2) : decimal.Parse(number1) / decimal.Parse(number2);
                numbers.Insert(i, item.ToString());
                i--;
            }
        }

        private static void AdditionAndSubtraction(List<string> operators, List<string> numbers)
        {
            for (var i = 0; i < operators.Count; i++)
            {
                if (operators[i] != "+" && operators[i] != "-") continue;
                var @operator = operators[i];
                operators.Remove(operators[i]);
                var number1 = numbers[i];
                var number2 = numbers[i + 1];
                numbers.Remove(number1);
                numbers.Remove(number2);
                var item = @operator == "+" ? decimal.Parse(number1) + decimal.Parse(number2) : decimal.Parse(number1) - decimal.Parse(number2);
                numbers.Insert(i, item.ToString());
                i--;
            }
        }
    }
}
