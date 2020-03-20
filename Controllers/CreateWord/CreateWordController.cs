using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.CreateWord
{
    public class CreateWordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}