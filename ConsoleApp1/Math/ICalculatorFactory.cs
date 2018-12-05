namespace ConsoleApp1.Math
{
    public interface ICalculatorFactory
    {
        ICalculator CreateCalculator(int factor);
    }
}
