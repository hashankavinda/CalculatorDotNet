using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IMemoryCache _cache;
        private readonly string cacheNumberOne = "numberOne";
        private readonly string cacheNumberTwo = "numberTwo";
        private readonly string cacheOperator = "operator";
        private readonly string cacheKey = "cacheKey";

        public CalculatorController(ILogger<CalculatorController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel cm, string btnName)
        {
            cm.Placeholder = "hello";
            return View(cm);
        }
    }
}
