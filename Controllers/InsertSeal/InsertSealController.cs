using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreSamples5.Controllers.InsertSeal
{
    public class InsertSealController : Controller
    {


        private readonly IWebHostEnvironment _webHostEnvironment;

        public InsertSealController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

            public IActionResult refresh()
        {


            // 复制服务器端的模板文件命名为新的文件名
            string webRootPath = _webHostEnvironment.WebRootPath;
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal1\\word1_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal1\\word1.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal2\\word2_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal2\\word2.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal3\\word3_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal3\\word3.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal4\\word4_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal4\\word4.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal5\\test_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal5\\test.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal6\\test_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal6\\test.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal7\\test_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal7\\test.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal8\\word8_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal8\\word8.doc", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSeal9\\word9_bak.doc", webRootPath + "\\InsertSeal\\Word\\AddSeal9\\word9.doc", true);


            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSign1\\word1_bak.doc ", webRootPath + "\\InsertSeal\\Word\\AddSign1\\word1.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSign2\\test_bak.doc ", webRootPath + "\\InsertSeal\\Word\\AddSign2\\test.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSign3\\test_bak.doc ", webRootPath + "\\InsertSeal\\Word\\AddSign3\\test.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSign4\\test_bak.doc ", webRootPath + "\\InsertSeal\\Word\\AddSign4\\test.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\AddSign5\\word_bak.doc ", webRootPath + "\\InsertSeal\\Word\\AddSign5\\word.doc ", true);

            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\bak\\test1.doc ", webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\test1.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\bak\\test2.doc ", webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\test2.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\bak\\test3.doc", webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\test3.doc ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\bak\\test4.doc", webRootPath + "\\InsertSeal\\Word\\BatchAddSeal\\doc\\test4.doc ", true);


            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSeal1\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSeal1\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSeal2\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSeal2\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSeal3\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSeal3\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSeal4\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSeal4\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSeal5\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSeal5\\test.xls ", true);

            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSign1\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSign1\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSign2\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSign2\\test.xls ", true);
            System.IO.File.Copy(webRootPath + "\\InsertSeal\\Excel\\AddSign3\\test_bak.xls ", webRootPath + "\\InsertSeal\\Excel\\AddSign3\\test.xls ", true);

            return Redirect("/InsertSeal/");
        }
    }
}