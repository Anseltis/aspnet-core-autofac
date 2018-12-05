using System;

namespace ConsoleApp1.Math
{
    public class Calculator: ICalculator
    {
        private readonly int _factor;

        public Calculator(int factor) => _factor = factor;

        public int Sum(int a, int b)
        {
            Console.WriteLine($"a={a}, b={b}");
            return _factor * (a + b);
        }
    }
}
