using Calculator.Models;

namespace Calculator.Infrastructure.Services
{
    public interface IService
    {
        public string CalculateExpression(CalculatorModel cm);
    }
}
