﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreConfiguration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using DotNetCoreConfiguration.Services;

namespace DotNetCoreConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;
        private readonly IRestrictedDataService restrictedDataService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env, IRestrictedDataService restrictedDataService)
        {
            _logger = logger;
            this.configuration = configuration;
            this.env = env;
            this.restrictedDataService = restrictedDataService;
        }

        public IActionResult Index()
        {
            ViewBag.IDEProvider = configuration.GetValue<string>("IDEProvider");
            ViewBag.CIProvider = configuration.GetValue<string>("CIProvider");


            ViewBag.CloudProvider = configuration.GetValue<string>("CloudProvider");
            ViewBag.Env = env.EnvironmentName;
            ViewBag.Value1 = configuration.GetValue<string>("section:section0:key:key0");
            ViewBag.Value2 = configuration.GetValue<string>("section:section0:key:key1");

            ViewBag.Value3 = configuration.GetValue<string>("section:section1:key:key0");
            ViewBag.Value4 = configuration.GetValue<string>("section:section1:key:key1");

            ViewBag.DefaultFramework = configuration.GetValue<string>("section:appSettings:key:defaultFramework");
            ViewBag.DefaultLanguage = configuration.GetValue<string>("section:appSettings:key:defaultLanguage");

            ViewBag.IniValue1 = configuration.GetValue<string>("sectionX:key0");
            ViewBag.IniValue2 = configuration.GetValue<string>("sectionX:key1");
            ViewBag.IniValue3 = configuration.GetValue<string>("sectionY:subsection:key");
            ViewBag.IniValue4 = configuration.GetValue<string>("sectionZ:subsection0:key");
            ViewBag.IniValue5 = configuration.GetValue<string>("sectionZ:subsection1:key");

            ViewBag.Data = restrictedDataService.GetData(Environment.GetEnvironmentVariable("DevSecret"));
            ViewBag.MoreData = restrictedDataService.GetMoreData(configuration.GetValue<string>("DevSecret2"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
