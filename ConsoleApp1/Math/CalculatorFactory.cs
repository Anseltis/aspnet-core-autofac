using Autofac;

namespace ConsoleApp1.Math
{
    class CalculatorFactory: ICalculatorFactory
    {
        private readonly IComponentContext _context;

        public CalculatorFactory(IComponentContext context) => _context = context;

        public ICalculator CreateCalculator(int factor)
        {
            return _context.Resolve<ICalculator>(new NamedParameter(nameof(factor), factor));
        }
    }
}
