using Calculator.Infrastructure.Services;
using Calculator.Models;

namespace UnitTests
{
    public class UnitTest1
    {
        private readonly IService _service;

        public UnitTest1()
        {
            var service = new Service();
            _service = service;
        }

        [Fact]
        public void Test_Evaluate_Math_Expression()
        {
            var cm1 = new CalculatorModel() { Placeholder = "1 + 2 * 3" }; //7
            var cm2 = new CalculatorModel() { Placeholder = "9 - 10 / 4" }; //6.5
            var cm3 = new CalculatorModel() { Placeholder = "0.5 * 1.5 - 0.25" }; //0.50

            var response1 = _service.CalculateExpression(cm1);
            var response2 = _service.CalculateExpression(cm2);
            var response3 = _service.CalculateExpression(cm3);

            Assert.Equal("7", response1);
            Assert.Equal("6.5", response2);
            Assert.Equal("0.50", response3);
        }
    }
}