using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.FileMaker
{
    public class FileMakerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            string url = "";
            url = _webHostEnvironment.WebRootPath;
            ViewBag.url = url + "\\FileMaker\\doc";
            return View();
        }

        public IActionResult FileMakerPDF()
        {
            PageOfficeNetCore.FileMakerCtrl fileMakerCtrl = new PageOfficeNetCore.FileMakerCtrl(Request);
            fileMakerCtrl.ServerPage = "../PageOffice/POServer";
            //设置保存页面
            fileMakerCtrl.SaveFilePage = "SaveDoc";

            PageOfficeNetCore.WordWriter.WordDocument doc = new PageOfficeNetCore.WordWriter.WordDocument();
            //禁用右击事件
            doc.DisableWindowRightClick = true;
            //给数据区域赋值，即把数据填充到模板中相应的位置
            doc.OpenDataRegion("PO_company").Value = "北京卓正志远软件有限公司";

            fileMakerCtrl.SetWriter(doc);
            fileMakerCtrl.JsFunction_OnProgressComplete = "OnProgressComplete()";
            fileMakerCtrl.FillDocumentAsPDF("../FileMakerPDF/doc/template.doc", PageOfficeNetCore.DocumentOpenType.Word, "a.pdf");

            ViewBag.fmCtrl = fileMakerCtrl.GetHtmlCode("FileMakerCtrl1");
            return View();
        }



        public async Task<ActionResult> SaveDoc()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;

            string fileName = "maker" + fs.FileExtName;
            fs.SaveToFile(webRootPath + "/FileMakerPDF/doc/" + fileName);
            fs.Close();
            return Content("OK");
        }
    }
}