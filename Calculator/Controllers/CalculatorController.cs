using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
