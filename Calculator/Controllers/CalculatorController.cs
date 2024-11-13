using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel cm)
        {
            cm.Placeholder = Convert.ToString(new DataTable().Compute(cm.Placeholder, null)) ?? "0";
            return View(cm);
        }
    }
}
