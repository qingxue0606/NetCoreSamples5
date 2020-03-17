using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace NetCoreSamples5.Controllers
{
    public class PageOfficeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PageOfficeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult POServer()
        {
            PageOfficeNetCore.POServer.Server poServer = new PageOfficeNetCore.POServer.Server(Request, Response);
            poServer.LicenseFilePath = _webHostEnvironment.ContentRootPath + "/Views/PageOffice/";
            poServer.Run();
            return Content("OK");
        }

        //for debug only
        //public ActionResult test()
        //{
        //    string contentRootPath = _webHostEnvironment.ContentRootPath;
        //    return Content(contentRootPath);
        //}
    }
}