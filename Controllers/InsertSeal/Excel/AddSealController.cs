using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal.Excel
{
    [Route("InsertSeal/Excel/{controller}/{action}")]
    public class AddSealController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddSealController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Excel1()
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
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSeal1/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc1()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSeal1/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Excel2()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc2";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSeal2/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc2()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSeal2/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Excel3()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("删除印章", "DeleteSeal()", 21);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc3";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSeal3/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc3()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSeal3/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Excel4()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc4";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSeal4/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc4()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSeal4/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Excel5()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("加盖印章", "InsertSeal()", 2);
            pageofficeCtrl.AddCustomToolButton("删除指定印章", "DeleteSeal()", 21);
            pageofficeCtrl.AddCustomToolButton("清除所有印章", "DeleteAllSeal()", 21);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc5";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSeal5/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc5()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSeal5/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }

    }
}