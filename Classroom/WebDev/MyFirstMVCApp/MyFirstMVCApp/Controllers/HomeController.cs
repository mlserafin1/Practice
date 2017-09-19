﻿using MyFirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            return View();
        }
        [HttpGet]
        public ActionResult Weather()
        {
            // This is where we would read weather data from a database or service
            CurrentWeather weather = new CurrentWeather();
            weather.Date = DateTime.Now;
            weather.High = 75;
            weather.Low = 62;
            weather.Description = "Sunny";

            return View(weather);
        }
    }
}