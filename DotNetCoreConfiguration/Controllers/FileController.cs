using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreConfiguration.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProvider fileProvider;

        public FileController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
