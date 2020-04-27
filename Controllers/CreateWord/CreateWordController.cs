using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace NetCoreSamples5.Controllers.CreateWord
{
    public class CreateWordController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateWordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        string connString = "Data Source=D:\\lic\\CreateWord.db";


        public IActionResult Index()
        {


            string op = Request.Query["op"];
            string FileSubject = Request.Query["FileSubject"];


            if (op != null && op.Length > 0)
            {
                Insert(FileSubject);
            }


            string sql = "select * from word order by ID desc ";
            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();
            StringBuilder strHtml = new StringBuilder();

            while (dr.Read())
            {
                strHtml.Append("<tr onmouseover='onColor(this)' onmouseout='offColor(this)'>\n");
                strHtml.Append("<td><a href =\"javascript:POBrowser.openWindowModeless('Word?filename="
                    + dr["FileName"].ToString() + "&subject="
                    + dr["Subject"].ToString() + "','width=1200px;height=800px;');\">"
                    + dr["Subject"].ToString() + "</a></td>\n");
                if (dr["SubmitTime"].ToString() != null && dr["SubmitTime"].ToString().Trim().Length > 0)
                {
                    strHtml.Append("<td>" + DateTime.Parse(dr["SubmitTime"].ToString()).ToString("yyyy/MM/dd") + "</td>\n");
                }
                else
                {
                    strHtml.Append("<td>&nbsp;</td>\n");
                }
                strHtml.Append(" </tr>\n");


            }
            ViewBag.strHtml = strHtml.ToString();
            return View();
        }

        private void Insert(string FileSubject)
        {

            string newID = "";

            string sql = "select Max(ID) from word";

            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();

            if (dr.Read() && dr[0].ToString().Trim().Length > 0)
            {
                newID = (Convert.ToInt32(dr[0]) + 1).ToString();

                //(int)dr[0]
            }
            dr.Close();
            string fileName = "aabb" + newID + ".doc";


            string strsql = "Insert into word(ID,FileName,Subject,SubmitTime) values(" + newID
            + ",'" + fileName + "','" + FileSubject + "','" + DateTime.Now.ToString() + "')";
            cmd.CommandText = strsql;
            cmd.ExecuteNonQuery();
            conn.Close();

            // 复制服务器端的模板文件命名为新的文件名


            string webRootPath = _webHostEnvironment.WebRootPath;


            System.IO.File.Copy(webRootPath + "\\CreateWord\\doc\\template.doc",
                webRootPath + "\\CreateWord\\doc\\" + fileName, true);

            //throw new NotImplementedException();
        }

        public IActionResult Word()
        {

            string fileName = Request.Query["fileName"];
            string subject = Request.Query["subject"];


            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save()", 1);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc";
            //打开Word文档

            //打开Word文档
            pageofficeCtrl.WebOpen("../CreateWord/doc/" + fileName, PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");

            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }


        public IActionResult CreateWord()
        {

            string fileName = Request.Query["fileName"];
            string subject = Request.Query["subject"];


            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save()", 1);

            pageofficeCtrl.JsFunction_BeforeDocumentSaved = "BeforeDocumentSaved()";


            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc";
            //打开Word文档

            pageofficeCtrl.WebCreateNew("张佚名", PageOfficeNetCore.DocumentVersion.Word2003);

            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }





    }
}