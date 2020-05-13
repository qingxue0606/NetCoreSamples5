using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal.Word
{
    
    public class AddSealController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddSealController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("InsertSeal/Word/AddSeal/Word1")]
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
            pageofficeCtrl.SaveFilePage = "SaveDoc";
            //打开Word文档
            pageofficeCtrl.WebOpen("/InsertSeal/Word/AddSeal1/word1.doc", PageOfficeNetCore.OpenModeType.docAdmin, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertSeal/Word/AddSeal1/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }


    }
}