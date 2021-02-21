using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter expression for calculate:");
                var expression = Console.ReadLine();
                var res = Calculator.Calculate(expression);
                Console.WriteLine("result: " + res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
  
}
