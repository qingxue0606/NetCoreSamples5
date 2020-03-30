using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers
{
    public class POBrowserTopicController : Controller
    {
        public IActionResult Index()
        {

            string userName = "张三";
            var bytes = System.Text.Encoding.UTF8.GetBytes(username);
            //Session["userName"] = userName;
            HttpContext.Session.Set("username", bytes);
            return View();
        }
    }
}