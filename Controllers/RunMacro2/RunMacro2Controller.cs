﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.RunMacro2
{
    public class RunMacro2Controller : Controller
    {
        public IActionResult Word()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";


            //打开Word文档
            pageofficeCtrl.WebOpen("../RunMacro2/doc/test.doc", PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }
    }
}