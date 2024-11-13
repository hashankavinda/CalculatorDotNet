using Calculator.Infrastructure.Services;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IService _service;

        public CalculatorController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel cm)
        {
            cm.Placeholder = _service.CalculateExpression(cm);
            return View(cm);
        }
    }
}
