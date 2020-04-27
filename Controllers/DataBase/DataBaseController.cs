using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace NetCoreSamples5.Controllers.DataBase
{
    public class DataBaseController : Controller
    {
        string connString = "Data Source=D:\\lic\\DataBase.db";

        public IActionResult Word()
        {
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "/PageOffice/POServer";

            //添加自定义按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save()", 1);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc?id=1";
            //打开Word文档
            pageofficeCtrl.WebOpen("Openstream?id=1", PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");
            return View();
        }
        public void Openstream()
        {
            string docID = Request.Query["id"];
            string sql = "Select Word,ID  from stream where ID='" + docID + "'";
            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long num = dr.GetBytes(0, 0, null, 0, Int32.MaxValue);
                Byte[] b = new Byte[num];
                dr.GetBytes(0, 0, b, 0, b.Length);
                Response.ContentType = "Application/msword"; //其他文件格式换成相应类型即可 application/x-excel, application/ms-powerpoint, application/pdf 
                Response.Headers.Add("Content-Disposition", "attachment; filename=down.doc");//其他文件格式换成相应类型的filename
                Response.Headers.Add("Content-Length", num.ToString());
                Response.Body.WriteAsync(b);
                Response.Clear();
            }
            dr.Close();
            conn.Close();
            Response.Body.Flush();
            Response.Body.Close();
        }

        public async Task<ActionResult> SaveDoc()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);

            await fs.LoadAsync();

            string sID = Request.Query["id"];

            string sql = "UPDATE  Stream SET Word=@file WHERE ID=" + sID;

            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            byte[] aa = fs.FileBytes;

            SqliteCommand cmd = new SqliteCommand(sql, conn);
            SqliteParameter parameter = new SqliteParameter("@file", SqliteType.Blob);
            parameter.Value = aa;
            cmd.Parameters.Add(parameter);
            cmd.ExecuteNonQuery();

            conn.Close();
            fs.Close();
            return Content("OK");
        }

    }
}