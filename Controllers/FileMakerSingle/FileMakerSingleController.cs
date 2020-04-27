using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.FileMakerSingle
{
    public class FileMakerSingleController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerSingleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            string url = "";
            url = _webHostEnvironment.WebRootPath + "/FileMakerSingle/doc/";
            ViewBag.url = url;
            return View();
        }
        public IActionResult FileMakerSingle()
        {

            PageOfficeNetCore.WordWriter.WordDocument doc = new PageOfficeNetCore.WordWriter.WordDocument();
            //禁用右击事件
            doc.DisableWindowRightClick = true;
            //给数据区域赋值，即把数据填充到模板中相应的位置
            doc.OpenDataRegion("PO_company").Value = "北京卓正志远软件有限公司";

            PageOfficeNetCore.FileMakerCtrl fileMakerCtrl = new PageOfficeNetCore.FileMakerCtrl(Request);
            fileMakerCtrl.ServerPage = "/PageOffice/POServer";

            fileMakerCtrl.SaveFilePage = "SaveDoc";
            fileMakerCtrl.SetWriter(doc);
            fileMakerCtrl.JsFunction_OnProgressComplete = "OnProgressComplete()";
            fileMakerCtrl.FileTitle = "newfilename.doc";
            fileMakerCtrl.FillDocument("../FileMakerSingle/doc/template.doc", PageOfficeNetCore.DocumentOpenType.Word);

            ViewBag.FMCtrl = fileMakerCtrl.GetHtmlCode("FileMakerCtrl1");
            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FileMakerSingle/doc/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
    }
}