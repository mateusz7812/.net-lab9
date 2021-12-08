
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab9.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private static int maxNumber = 10;
        private static int tryNumber = 0;

        private static int number = RandomNumber(maxNumber);

        private static int RandomNumber(int max)
        {
            return new Random().Next(max-1);
        }

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [Route("set,{n}")]
        public IActionResult Set(int n)
        {
            if(n > 0) 
                maxNumber = n;
            number = RandomNumber(maxNumber);
            ViewBag.maxNumber = maxNumber;
            return View();
        }

        [Route("draw")]
        public IActionResult Draw()
        {  
            number = RandomNumber(maxNumber);
            ViewBag.maxNumber = maxNumber;
            tryNumber = 0;
            return View();
        }

        [Route("guess,{n}")]
        public IActionResult Guess(int n)
        {
            ViewBag.inputNumber = n;
            ViewBag.number = number;
            ViewBag.maxNumber = maxNumber;
            ViewBag.tryNumber = ++tryNumber;
            return View();
        }
    }
}