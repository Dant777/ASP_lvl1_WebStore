﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult CheackOut()
        {
            return View();
        }
        public IActionResult ConractUs()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ProductDetaling()
        {
            return View();
        }
    }
}