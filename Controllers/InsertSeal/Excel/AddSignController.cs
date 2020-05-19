using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal.Excel
{
    [Route("InsertSeal/Excel/{controller}/{action}")]
    public class AddSignController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddSignController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Excel1()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "AddHandSign()", 3);
            pageofficeCtrl.AddCustomToolButton("删除签字", "DeleteHandSign()", 21);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc1";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSign1/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc1()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSign1/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


        public IActionResult Excel2()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "AddHandSign()", 3);
            pageofficeCtrl.AddCustomToolButton("修改密码", "ChangePsw()", 0);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc2";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSign2/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc2()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSign2/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
        public IActionResult Excel3()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";
            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save", 1);
            pageofficeCtrl.AddCustomToolButton("签字", "AddHandSign()", 3);
            pageofficeCtrl.AddCustomToolButton("验证印章", "VerifySeal()", 5);
            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc3";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Excel/AddSign3/test.xls", PageOfficeNetCore.OpenModeType.xlsNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc3()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Excel/AddSign3/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }
    }
}