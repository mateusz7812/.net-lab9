
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab9.Controllers
{
    public class ToolController : Controller
    {
        private readonly ILogger<ToolController> _logger;

        public ToolController(ILogger<ToolController> logger)
        {
            _logger = logger;
        }

        [Route("tool/solve")]
        public IActionResult Solve()
        {
            return View();
        }

        [Route("tool/solve/{a}/{b}/{c}")]
        public IActionResult SolveWithNumbers(Double a, Double b, Double c)
        {
            (ViewBag.x1, ViewBag.x2, ViewBag.results) = Calc(a, b, c); 
            (ViewBag.a, ViewBag.b, ViewBag.c) = (a, b, c);
            switch(ViewBag.results){
                case 2:
                    ViewBag.sectionClass = "twoResults";
                    break;
                case 1:
                    ViewBag.sectionClass = "oneResult";
                    break;
                default:
                    ViewBag.sectionClass = "noResults";
                    break;
            }
            return View();
        }

        static public (Double?, Double?, int?) Calc(Double a, Double b, Double c)
        {
            Double? x1 = null;
            Double? x2 = null;
            int? results_number = 0;

            if(a == 0){
                if (b != 0) {
                    x1 = -c / b;
                    results_number = 1;
                }
                else{
                    if(c == 0)
                        results_number = null;
                }
            }
            else{
                Double delta = b * b - 4 * a * c;
                if (delta == 0)
                {
                    x1 = (-b) / (2 * a);
                    results_number = 1;
                }
                else if (delta > 0)
                {
                    Double deltaSqrt = Math.Sqrt(delta);
                    x1 = (-b - deltaSqrt) / (2 * a);
                    x2 = (-b + deltaSqrt) / (2 * a);
                    results_number = 2;
                }
            }
            
            return (x1, x2, results_number);
        }
    }
}