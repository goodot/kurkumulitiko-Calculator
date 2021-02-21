using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculator
{
    public static class Calculator
    {
        public static double Calculate(string s)
        {
            s = s.Replace(" ", string.Empty);
            List<string> operators = new List<string>();
            List<string> numbers = new List<string>();
            while (s.IndexOf(")") > 0)
            {
                parentheses(ref s);
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
            multiplicationAnddivision(operators, numbers);
            additionAndsubtraction(operators, numbers);
            return double.Parse(numbers[0]);
        }

        public static void parentheses(ref string s)
        {
            int right = s.IndexOf(")");
            if (right > 0)
            {
                int left = s.Substring(0, right).LastIndexOf("(");

                string subs = s.Substring(left + 1, right - left - 1);
                s = s.Substring(0, left) + Calculate(subs) + s.Substring(right + 1);
            }
        }
        public static string ReadNextOperator(ref string s)
        {
            string _operator = s.Substring(0, 1);
            s = s.Substring(1);
            return _operator;
        }
        public static string ReadNextNumber(ref string s)
        {
            string _number = s.Substring(0, 1);
            for (int i = 1; i < s.Length; i++)
            {
                var letter = s[i];
                if (letter != '+' && letter != '-' && letter != '*' && letter != '/')
                    _number += letter;
                else
                    break;
            }
            s = s.Substring(_number.Length);
            return _number;
        }
        public static void multiplicationAnddivision(List<string> operators, List<string> numbers)
        {
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == "*" || operators[i] == "/")
                {
                    string _operator = operators[i];
                    operators.Remove(operators[i]);
                    string number1 = numbers[i];
                    string number2 = numbers[i + 1];
                    numbers.Remove(number1);
                    numbers.Remove(number2);
                    double item = _operator == "*" ? double.Parse(number1) * double.Parse(number2) : double.Parse(number1) / double.Parse(number2);
                    numbers.Insert(i, item.ToString());
                    i--;
                }
            }
        }
        public static void additionAndsubtraction(List<string> operators, List<string> numbers)
        {
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == "+" || operators[i] == "-")
                {
                    string _operator = operators[i];
                    operators.Remove(operators[i]);
                    string number1 = numbers[i];
                    string number2 = numbers[i + 1];
                    numbers.Remove(number1);
                    numbers.Remove(number2);
                    double item = _operator == "+" ? double.Parse(number1) + double.Parse(number2) : double.Parse(number1) - double.Parse(number2);
                    numbers.Insert(i, item.ToString());
                    i--;
                }
            }
        }
        //public static double Calculate(string expression)
        //{
        //    DataTable dt = new DataTable();
        //    var res = Math.Round(Convert.ToDouble(dt.Compute(expression, "")), 10);
        //    return res;
        //}
    }
}
