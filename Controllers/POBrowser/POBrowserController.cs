using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace NetCoreSamples5.Views
{
    public class POBrowserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public POBrowserController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            pageofficeCtrl.SaveFilePage = "POSaveDoc";
            //pageofficeCtrl.WebOpen("doc/test.doc", PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            pageofficeCtrl.WebOpen("doc/test.doc", PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");
            return View();
        }

        public async Task<ActionResult> POSaveDoc()
        {

            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            fs.SaveToFile(webRootPath + "/POBrowser/doc/" + fs.FileName);

            await Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fs.FileName));




            fs.ShowPage(300, 300);
            fs.Close();
            return Content("OK");
        }
    }
}