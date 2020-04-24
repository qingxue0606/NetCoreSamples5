using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace NetCoreSamples5.Controllers.WordSalaryBill
{


    
    public class WordSalaryBillController : Controller
    {
        string connString = "Data Source=D:\\lic\\WordSalaryBill.db";
        public IActionResult Index()
        {

            string sql = "select * from Salary   order by ID ";
            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SqliteDataReader dr = cmd.ExecuteReader();
            StringBuilder strHtmls = new StringBuilder();
            strHtmls.Append("<tr  style='height:40px;padding:0; border-right:1px solid #a2c5d9; border-bottom:1px solid #a2c5d9; background:#edf8fe; font-weight:bold; color:#666;text-align:center; text-indent:0px;'>");
            strHtmls.Append("<td width='5%' >选择</td>");
            strHtmls.Append("<td width='10%' >员工编号</td>");
            strHtmls.Append("<td width='10%' >员工姓名</td>");
            strHtmls.Append("<td width='15%' >所在部门</td>");
            strHtmls.Append("<td width='10%' >应发工资</td>");
            strHtmls.Append("<td width='10%' >扣除金额</td>");
            strHtmls.Append("<td width='10%' >实发工资</td>");
            strHtmls.Append("<td width='10%' >发放日期</td>");
            strHtmls.Append("<td width='20%' >操作</td>");
            strHtmls.Append("</tr>");

            bool flg = false;


            while (dr.Read())
            {
                flg = true;
                decimal result = 0;
                DateTime date = DateTime.Now;
                string pID = dr["ID"].ToString().Trim();
                strHtmls.Append("<tr  style='height:40px; text-indent:10px; padding:0; border-right:1px solid #a2c5d9; border-bottom:1px solid #a2c5d9; color:#666;'>");
                strHtmls.Append("<td style=' text-align:center;'><input id='check" + pID + "'  type='checkbox' /></td>");
                strHtmls.Append("<td style=' text-align:left;'>" + pID + "</td>");
                strHtmls.Append("<td style=' text-align:left;'>" + dr["UserName"].ToString() + "</td>");
                strHtmls.Append("<td style=' text-align:left;'>" + dr["DeptName"].ToString() + "</td>");
                if (dr["SalTotal"] != null && decimal.TryParse(dr["SalTotal"].ToString(), out result))
                {
                    strHtmls.Append("<td style=' text-align:left;'>" + decimal.Parse(dr["SalTotal"].ToString()) + "</td>");
                }
                else
                {
                    strHtmls.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["SalDeduct"] != null && decimal.TryParse(dr["SalDeduct"].ToString(), out result))
                {
                    strHtmls.Append("<td style=' text-align:left;'>" + decimal.Parse(dr["SalDeduct"].ToString()) + "</td>");
                }
                else
                {
                    strHtmls.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["SalCount"] != null && decimal.TryParse(dr["SalCount"].ToString(), out result))
                {
                    strHtmls.Append("<td style=' text-align:left;'>" + decimal.Parse(dr["SalCount"].ToString()) + "</td>");
                }
                else
                {
                    strHtmls.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["DataTime"] != null && DateTime.TryParse(dr["DataTime"].ToString(), out date))
                {
                    strHtmls.Append("<td style=' text-align:center;'>" + DateTime.Parse(dr["DataTime"].ToString()).ToString("yyyy-MM-dd") + "</td>");
                }
                else
                {
                    strHtmls.Append("<td style=' text-align:left;'>" + DateTime.Now.ToString("yyyy-MM-dd") + "</td>");
                }
                strHtmls.Append("<td style=' text-align:center;'><a href='javascript:POBrowser.openWindowModeless(\"ViewWord?ID=" + pID + "\" ,\"width=1200px;height=800px;\");' >查看</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:POBrowser.openWindowModeless(\"Openfile?ID=" + pID + "\" ,\"width=1200px;height=800px;\");'>编辑</a></td>");
                strHtmls.Append("</tr>");
            }
            if (!flg)
            {
                strHtmls.Append("<tr>\r\n");
                strHtmls.Append("<td width='100%' height='100' align='center'>对不起，暂时没有可以操作的数据。\r\n");
                strHtmls.Append("</td></tr>\r\n");
            }
            ViewBag.strHtmls = strHtmls.ToString();
            dr.Close();
            conn.Close();
            return View();
        }

        public IActionResult ViewWord()
        {
            String err = "";
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            string id = Request.Query["ID"];


            if (id != null && id.Length > 0)
            {
                string sql = "select * from Salary where id =" + id + " order by ID"; ;
                SqliteConnection conn = new SqliteConnection(connString);
                conn.Open();
                SqliteCommand cmd = new SqliteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                SqliteDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    decimal result = 0;
                    DateTime date = DateTime.Now;

                    //创建WordDocment对象
                    PageOfficeNetCore.WordWriter.WordDocument doc = new PageOfficeNetCore.WordWriter.WordDocument();
                    //打开数据区域
                    PageOfficeNetCore.WordWriter.DataRegion datareg = doc.OpenDataRegion("PO_table");
                    //打开Table
                    PageOfficeNetCore.WordWriter.Table table = datareg.OpenTable(1);
                    ////给单元格赋值
                    table.OpenCellRC(2, 1).Value = dr["ID"].ToString();
                    table.OpenCellRC(2, 2).Value = dr["UserName"].ToString();
                    table.OpenCellRC(2, 3).Value = dr["DeptName"].ToString();

                    if (dr["SalTotal"] != null && decimal.TryParse(dr["SalTotal"].ToString(), out result))
                    {
                        table.OpenCellRC(2, 4).Value = decimal.Parse(dr["SalTotal"].ToString()).ToString("c");
                    }
                    else
                    {
                        table.OpenCellRC(2, 4).Value = "￥0.00";
                    }

                    if (dr["SalDeduct"] != null && decimal.TryParse(dr["SalDeduct"].ToString(), out result))
                    {
                        table.OpenCellRC(2, 5).Value = int.Parse(dr["SalDeduct"].ToString()).ToString("c");
                    }
                    else
                    {
                        table.OpenCellRC(2, 5).Value = "￥0.00";
                    }

                    if (dr["SalCount"] != null && decimal.TryParse(dr["SalCount"].ToString(), out result))
                    {
                        table.OpenCellRC(2, 6).Value = int.Parse(dr["SalCount"].ToString()).ToString("c");
                    }
                    else
                    {
                        table.OpenCellRC(2, 6).Value = "￥0.00";
                    }

                    if (dr["DataTime"] != null && DateTime.TryParse(dr["DataTime"].ToString(), out date))
                    {
                        table.OpenCellRC(2, 7).Value = DateTime.Parse(dr["DataTime"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        table.OpenCellRC(2, 7).Value = "";
                    }

                    pageofficeCtrl.SetWriter(doc);
                }
                else
                {
                    err = "<script>alert('未获得该员工的工资信息！');location.href='index.jsp'</script>";
                }
                dr.Close();
                conn.Close();


                //打开Word文档
                
            }
            else
            {
                err = "<script>alert('未获得该员工的工资信息！');location.href='index.jsp'</script>";
            }

            pageofficeCtrl.WebOpen("../WordSalaryBill/doc/template.doc", PageOfficeNetCore.OpenModeType.docReadOnly, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");
            ViewBag.err = err;

            return View();
        }


        public IActionResult Openfile()
        {
            String err = "";
            PageOfficeNetCore.PageOfficeCtrl pageofficeCtrl = new PageOfficeNetCore.PageOfficeCtrl(Request);
            pageofficeCtrl.ServerPage = "../PageOffice/POServer";

            string id = Request.Query["ID"];


            if (id != null && id.Length > 0)
            {
                string sql = "select * from Salary where id =" + id + " order by ID"; ;
                SqliteConnection conn = new SqliteConnection(connString);
                conn.Open();
                SqliteCommand cmd = new SqliteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                SqliteDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    decimal result = 0;
                    DateTime date = DateTime.Now;

                    //创建WordDocment对象
                    PageOfficeNetCore.WordWriter.WordDocument doc = new PageOfficeNetCore.WordWriter.WordDocument();
                    //打开数据区域
                    PageOfficeNetCore.WordWriter.DataRegion datareg = doc.OpenDataRegion("PO_table");
                    //给数据区域赋值
                    doc.OpenDataRegion("PO_ID").Value = id;

                    //设置数据区域的可编辑性
                    doc.OpenDataRegion("PO_UserName").Editing = true;
                    doc.OpenDataRegion("PO_DeptName").Editing = true;
                    doc.OpenDataRegion("PO_SalTotal").Editing = true;
                    doc.OpenDataRegion("PO_SalDeduct").Editing = true;
                    doc.OpenDataRegion("PO_SalCount").Editing = true;
                    doc.OpenDataRegion("PO_DataTime").Editing = true;

                    doc.OpenDataRegion("PO_UserName").Value = dr["UserName"].ToString();
                    doc.OpenDataRegion("PO_DeptName").Value = dr["DeptName"].ToString();

                    if (dr["SalTotal"] != null && decimal.TryParse(dr["SalTotal"].ToString(), out result))
                    {
                        doc.OpenDataRegion("PO_SalTotal").Value = decimal.Parse(dr["SalTotal"].ToString()).ToString("c");
                    }
                    else
                    {
                        doc.OpenDataRegion("PO_SalTotal").Value = "￥0.00";
                    }

                    if (dr["SalDeduct"] != null && decimal.TryParse(dr["SalDeduct"].ToString(), out result))
                    {
                        doc.OpenDataRegion("PO_SalDeduct").Value = int.Parse(dr["SalDeduct"].ToString()).ToString("c");
                    }
                    else
                    {
                        doc.OpenDataRegion("PO_SalDeduct").Value = "￥0.00";
                    }

                    if (dr["SalCount"] != null && decimal.TryParse(dr["SalCount"].ToString(), out result))
                    {
                        doc.OpenDataRegion("PO_SalCount").Value = int.Parse(dr["SalCount"].ToString()).ToString("c");


                        doc.OpenDataRegion("PO_SalCount").Value = dr["SalCount"].ToString();
                    }
                    else
                    {
                        doc.OpenDataRegion("PO_SalCount").Value = "￥0.00";
                        doc.OpenDataRegion("PO_SalCount").Value = dr["SalCount"].ToString();
                    }

                    if (dr["DataTime"] != null && DateTime.TryParse(dr["DataTime"].ToString(), out date))
                    {
                        doc.OpenDataRegion("PO_DataTime").Value = DateTime.Parse(dr["DataTime"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        doc.OpenDataRegion("PO_DataTime").Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                    pageofficeCtrl.AddCustomToolButton("保存", "Save()", 1);
                    pageofficeCtrl.SaveDataPage = "SaveData?id=" + id;
                    pageofficeCtrl.SetWriter(doc);
                }
                else
                {
                    err = "<script>alert('未获得该员工的工资信息！');location.href='index.jsp'</script>";
                }
                dr.Close();
                conn.Close();


                //打开Word文档

            }
            else
            {
                err = "<script>alert('未获得该员工的工资信息！');location.href='index.jsp'</script>";
            }

            pageofficeCtrl.WebOpen("../WordSalaryBill/doc/template.doc", PageOfficeNetCore.OpenModeType.docSubmitForm, "tom");
            ViewBag.POCtrl = pageofficeCtrl.GetHtmlCode("PageOfficeCtrl1");
            ViewBag.err = err;

            return View();
        }

        public async Task<ActionResult> SaveData()
        {


            string id = Request.Query["id"];

            PageOfficeNetCore.WordReader.WordDocument doc = new PageOfficeNetCore.WordReader.WordDocument(Request, Response);
            await doc.LoadAsync();

            string userName = "", deptName = "", salTotoal = "0", salDeduct = "0", salCount = "0", dateTime = "";
            //-----------  PageOffice 服务器端编程开始  -------------------//
            userName = doc.OpenDataRegion("PO_UserName").Value;
            deptName = doc.OpenDataRegion("PO_DeptName").Value;
            salTotoal = doc.OpenDataRegion("PO_SalTotal").Value;
            salDeduct = doc.OpenDataRegion("PO_SalDeduct").Value;
            salCount = doc.OpenDataRegion("PO_SalCount").Value;
            dateTime = doc.OpenDataRegion("PO_DataTime").Value;




            string sql = "UPDATE Salary SET UserName='" + userName
                + "',DeptName='" + deptName + "',SalTotal='" + salTotoal
                + "',SalDeduct='" + salDeduct + "',SalCount='" + salCount
                + "',DataTime='" + dateTime + "' WHERE ID=" + id;

            SqliteConnection conn = new SqliteConnection(connString);
            conn.Open();

            SqliteCommand cmd = new SqliteCommand(sql, conn);


            cmd.ExecuteNonQuery();
            conn.Close();
    



            doc.Close();




            return Content("OK");
        }




    }
}