﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace NetCoreSamples5.Controllers.SaveAndSearch
{
    public class SaveAndSearchController : Controller
    {
        string connString = "Data Source=D:\\lic\\SaveAndSearch.db";

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SaveAndSearchController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            StringBuilder strHtml = new StringBuilder();

            string key = Request.Query["Input_KeyWord"].ToString();

            key = Request.Query["Input_KeyWord"].ToString();
            key = System.Web.HttpUtility.UrlDecode(key, System.Text.Encoding.UTF8);

            string sql ;

            if (key != null && key.Length > 0)
            {
                sql = "select * from word  where Content like '%" + key + "%' order by ID desc";
            }
            else
            {
                sql = "select * from word order by ID desc ";
            }

        
            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            while (dr.Read()) {
                strHtml.Append("<tr onmouseover='onColor(this)' onmouseout='offColor(this)'>\n");
                strHtml.Append("<td>" + dr["FileName"].ToString()    + "</td>\n");
                strHtml.Append("<td style='text-align:center;'><a style=' color:#00217d;' href='javascript:POBrowser.openWindowModeless(\"Word?ID=" + dr["ID"].ToString() + "\",\"width=1200px;height=800px;\",\"" 
                    + key + "\");' >编辑</a></td>\n");
                strHtml.Append(" </tr>\n");

                flag = true;
            }
            if (!flag) {
                strHtml.Append("<tr>\r\n");
                strHtml.Append("<td colspan='2' style='width:100%; text-align:center;'>对不起，没有搜索到相应的数据。\r\n");
                strHtml.Append("</td></tr>\r\n");

            }
            ViewBag.strHtml = strHtml.ToString();

                return View();
        }

        public IActionResult Word()
        {
            string id = Request.Query["id"].ToString().Trim();
            string sql = "select * from word where id=" + id; 
            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();

            string fileName = "";
            if (dr.Read())
            {
                if (dr["FileName"] != null && dr["FileName"].ToString().Length > 0)
                {
                    fileName = dr["FileName"].ToString().Trim() + ".doc";
                }
            }
            dr.Close();
            conn.Close();

            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            //添加自定义工具栏按钮
            pageofficeCtrl.AddCustomToolButton("保存", "Save()", 1);

            //设置保存页面
            pageofficeCtrl.SaveFilePage = "SaveDoc?id=" + id;
            //打开Word文档

            string webRootPath = _webHostEnvironment.WebRootPath;

            pageofficeCtrl.WebOpen(webRootPath + "\\SaveAndSearch\\doc\\" + fileName, PageOfficeNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");

            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            PageOfficeNetCore.FileSaver fs = new PageOfficeNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();

            string id = Request.Query["id"].ToString().Trim();
            string content = fs.DocumentText;

            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            string sql = "update word set Content='" + content + "' where id=" + id;
            SqliteCommand cmd = new SqliteCommand(sql, conn);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SaveAndSearch/doc/" + fs.FileName);
            fs.Close();
            return Content("OK");
        }



    }
}