using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal.Word
{
    [Route("InsertSeal/Word/{controller}/{action}")]
    public class AddSealController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddSealController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word1()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("删除印章", "DeleteSeal()", 21);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc1";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal1/word1.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc1()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal1/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Word2()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc2";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal2/word2.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc2()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal2/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Word3()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc3";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal3/word3.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc3()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal3/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }

        public IActionResult Word4()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("添加印章位置", "InsertSealPos()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc4";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal4/word4.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc4()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal4/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Word5()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("盖章到印章位置", "AddSealByPos()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc5";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal5/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc5()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal5/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }

        public IActionResult Word6()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("盖章到印章位置", "AddSealByPos()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc6";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal6/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc6()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal6/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Word7()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("盖章到印章位置", "AddSealByPos()", 2);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc7";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal7/test.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc7()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal7/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Word8()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc8";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal8/word8.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc8()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal8/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Word9()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("删除指定印章", "DeleteSeal()", 21);
            pageofficeCtrl.AddCustomToolButton("清除所有印章", "DeleteAllSeal()", 21);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc9";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal9/word9.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc9()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal9/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
    }
}