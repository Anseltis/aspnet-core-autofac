using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp1.Math;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class HomeController: Controller
    {
        private readonly Lazy<ICalculator> _calculatorLazy;
        private ICalculator Calculator => _calculatorLazy.Value;

        public HomeController(ICalculatorFactory calculatorFactory)
        {
            _calculatorLazy = new Lazy<ICalculator>(() => calculatorFactory.CreateCalculator(10));
        }

        [Route("index"), HttpGet]
        public ActionResult Index()
        {
            return Json(new { values = Calculator.Sum(2, 3) });
        }

        [Route("values"), HttpGet]
        public ActionResult Values(string str)
        {
            return Json(new { values = Calculator.Sum(2, 3) });
        }
    }
}
