﻿using Microsoft.AspNetCore.Mvc;
using MSIT150Site.Models;
using System.Diagnostics;

namespace MSIT150Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult First()
        {

            return View();
        }
        public IActionResult GetDemo()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
        public IActionResult partial1()
        {
            return PartialView();
        }
        public IActionResult partial2()
        {
            ViewBag.Message="這是一個partial  2";
            return PartialView();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}