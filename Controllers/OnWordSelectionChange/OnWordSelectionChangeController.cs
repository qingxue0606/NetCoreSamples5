﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.OnWordSelectionChange
{
    public class OnWordSelectionChangeController : Controller

       
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OnWordSelectionChangeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";
            pageofficeCtrl.CustomToolbar = false;
            pageofficeCtrl.JsFunction_OnWordDataRegionClick= "OnWordSelectionChange()";

            //打开Word文档
            pageofficeCtrl.WebOpen("../OnWordSelectionChange/doc/test.doc", PageOfficeNetCore.OpenModeType.docReadOnly, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }


    }
}