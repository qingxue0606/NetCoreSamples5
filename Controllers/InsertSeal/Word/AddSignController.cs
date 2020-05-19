using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal.Word
{
    [Route("InsertSeal/Word/{controller}/{action}")]
    public class AddSignController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddSignController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Word1()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "InsertHandSign()", 3);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc1";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSign1/word1.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc1()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSign1/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Word2()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "InsertHandSign()", 3);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc2";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSign2/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc2()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSign2/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Word3()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "InsertHandSign()", 3);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc3";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSign3/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc3()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSign3/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }

        public IActionResult Word4()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "InsertHandSign()", 3);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc4";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSign4/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc4()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSign4/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Word5()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "InsertHandSign()", 3);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc5";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSign5/word.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc5()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSign5/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }

    }
}