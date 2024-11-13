using Calculator.Models;
using System.Data;

namespace Calculator.Infrastructure.Services
{
    public class Service : IService
    {
        public string CalculateExpression(CalculatorModel cm)
        {
            try
            {
                return Convert.ToString(new DataTable().Compute(cm.Placeholder, null)) ?? "Invalid expression";
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return "Error in calculating";
            }
        }
    }
}
