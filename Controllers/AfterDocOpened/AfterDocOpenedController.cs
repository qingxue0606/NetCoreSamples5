using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.AfterDocOpened
{
    public class AfterDocOpenedController : Controller
    {
        public IActionResult Word()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            // 设置文件打开后执行的js function
            pageofficeCtrl.JsFunction_AfterDocumentOpened = "AfterDocumentOpened()";
            //打开Word文档
            pageofficeCtrl.WebOpen("../AfterDocOpened/doc/test.doc", PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }
    }
}