using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace NetCoreSamples5.Controllers
{
    public class Seals
    {
        public int ID { set; get; }
        public string SealName { set; get; }
        public string SealType { set; get; }
        public int DeptID { set; get; }
        public string DeptName { set; get; }
        public int SignerID { set; get; }
        public string SignerName { set; get; }

        public DateTime CreateTime { set; get; }

        public DateTime UpdateTime { set; get; }

        public string Status { set; get; }

        public string Description { set; get; }

        public string AuthType { set; get; }

        public string CertSerialNum { set; get; }

        public string IssueTo { set; get; }

        public string IssueBy { set; get; }

        public string  ValidFrom { set; get; }

        public string ValidTo { set; get; }
        public string CertPKCS7 { set; get; }
        public byte[] SealImage { set; get; }
        public string SealImageType { set; get; }
        public string Vcode { set; get; }
    }

    public class Users 
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public  int DeptID { set; get; }
        public string DeptName { set; get; }
        public int RoleID { set; get; }
        public string RoleName { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
        public  string EmployNo { set; get; }
        public string Duty { set; get; }
        public string Sex { set; get; }
        public string Tel { set; get; }
        public string Email { set; get; }
        public string Description { set; get; }
        public string IP { set; get; }
        public string CertPKCS7 { set; get; }
        public string Status { set; get; }





    }
    public class SealController : Controller
    {
        private string m_Charset = "UTF-8";
        string errMsg = "";//全局异常信息
        string connString = "Data Source=D:\\lic\\poseal.db";
        string loginFilePath = "D:\\loginseal.dat";
        string adminFilePath = "D:\\adminseal.dat";

        public async Task LoginSeal(string userName, string password)
        {
            string strLoginOutPage = "";
            string pathType = Request.Path;
            strLoginOutPage = OutPageStr(pathType);
            if (userName == null && password == null)
            {
                //说明第一次访问，并没有点击登录，不存在Errmsg为空。
                strLoginOutPage = strLoginOutPage.Replace("<%=errmsg %>", "");
                var data = Encoding.UTF8.GetBytes(strLoginOutPage);
                await Response.Body.WriteAsync(data, 0, data.Length);

            }
            else
            {
                if (userName == null || password == null)
                {
                    //用户名或者密码忘记输入
                    errMsg = "请输入用户名和密码！";
                    strLoginOutPage = strLoginOutPage.Replace("<%=errmsg %>", errMsg);
                    var data = Encoding.UTF8.GetBytes(strLoginOutPage);
                    await Response.Body.WriteAsync(data, 0, data.Length);
                }

                if ((!userName.Trim().Equals("admin")) || (!password.Trim().Equals("111111")))
                {
                    errMsg = "用户名或密码错误！";
                    strLoginOutPage = strLoginOutPage.Replace("<%=errmsg %>", errMsg);
                    var data = Encoding.UTF8.GetBytes(strLoginOutPage);
                    await Response.Body.WriteAsync(data, 0, data.Length);
                }
                else
                {
                    HttpContext.Session.SetString("UserName", userName);
                    HttpContext.Session.SetString("Password", password);
                    Response.Redirect("AdminSeal");
                }
            }

        }

       
        public async Task AdminSeal(string op, IFormFile file1)
        {
            string UserName = HttpContext.Session.GetString("UserName");
            if (UserName == null || UserName.Length <= 0)
            {
                Response.Redirect("LoginSeal");
                return;
            }
            bool flg = true;//标识是否有印章
            bool addFlg = false;//标识印章图片上传成功后或者图片上传失败时应显示印章添加页面


            // 保存用户填写的印章信息
            string strSealName = "";
            string strSingerName = "";
            string strSealType = "";
            string strDeptName = "";
            string strTmpPicPath = "";//上传图片的路径
            string strImgBase64 = "";//图片的base64
            byte[] imageBytes = null;//图片的byte


            string errMsgUpload = "";//标识上传失败信息
            string sucUploadMsg = "";//标识上传成功信息
            string errMsgAdd = "";//标识添加印章失败信息
            string sucMsg = "";//标识添加印章成功信息  
            string strImageType = "";//标识上传图片的类型

            string strAdminOutPage = "";
            string pathType = Request.Path;
            StringBuilder strTable = new StringBuilder();

            string fileName = "";//上传的图片名称
            //上传图片
            if (op != null && op.Trim().Equals("upload"))
            {
                addFlg = true;
                strSealName = System.Web.HttpUtility.UrlDecode(Request.Query["sealName"], System.Text.Encoding.UTF8);
                strSingerName = System.Web.HttpUtility.UrlDecode(Request.Query["singerName"], System.Text.Encoding.UTF8);
                strDeptName = System.Web.HttpUtility.UrlDecode(Request.Query["deptName"], System.Text.Encoding.UTF8);
                strSealType = System.Web.HttpUtility.UrlDecode(Request.Query["sealType"], System.Text.Encoding.UTF8);
                try
                {
                    if (file1 != null)
                    {
                        if (file1.Length > 0)
                        {
                            fileName = file1.FileName;
                            strTmpPicPath = Path.GetTempFileName();//C:\\Users\\Dong\\AppData\\Local\\Temp\\tmp2C68.tmp，上传图片的临时存放路径

                            using (var stream = System.IO.File.Create(strTmpPicPath))
                            {
                                if (strTmpPicPath.LastIndexOf(".") > 0)
                                {
                                    String fileExt = fileName.Substring(fileName.LastIndexOf("."));
                                    fileExt = fileExt.ToLower();
                                    //增加扩展名过滤，避免webshell攻击。黑客构造上传的xml，指定文件名为test.jsp，可成功上传webshell。
                                    if (fileExt.Equals(".bmp") || fileExt.Equals(".gif") || fileExt.Equals(".jpg") || fileExt.Equals(".png"))
                                    {
                                    }
                                    else
                                    {
                                        fileName = "";
                                        throw new Exception("The file format is not allowed!");
                                    }
                                }
                                await file1.CopyToAsync(stream);//将上传的图片拷贝到临时文件夹中
                                strImageType = file1.ContentType;
                            }
                            //将临时文件夹中的图片转成base64输出        
                            FileStream filestream = new FileStream(strTmpPicPath, FileMode.Open);
                            byte[] bt = new byte[filestream.Length];
                            //调用read读取方法
                            filestream.Read(bt, 0, bt.Length);
                            filestream.Close();
                            //将byte转成base64
                            strImgBase64 = Convert.ToBase64String(bt);
                            sucUploadMsg = "上传成功！";

                        }

                    } else {
                        //file1==null
                        errMsgUpload = "请选择上传的图片！";
                    }

                } catch (Exception e) {
                    errMsg += "上传失败，失败原因：" + e.Message.Replace("\"", "”") + "！";
                }
                if (errMsg.Trim().Length > 0)
                {
                    errMsgUpload = errMsg;
                    errMsg = "";
                }

            }
            //添加印章
            if (op != null && op.Trim().Equals("add"))
            {
                strSealName = Request.Form["txtSealName"];
                strSingerName = Request.Form["txtSignerName"];
                strSealType = Request.Form["SelectSealType"];
                strDeptName = Request.Form["txtDeptName"];
                strImageType = Request.Form["ipt_ImageType"];
                strTmpPicPath = Request.Form["ipt_TmpPicPath"];
                if (strSealName == null || strSealName.Trim().Length == 0)
                {
                    errMsg = "请输入印章名称！ ";
                }

                if (strSingerName == null || strSingerName.Trim().Length == 0)
                {
                    errMsg += "请输入签章人姓名！";
                }

                if (strTmpPicPath.Equals("") || strImageType.Equals(""))
                {
                    errMsg += "未获得图片信息，请重新上传！";
                }

                if (errMsg.Length == 0) {
                    string sealName = Request.Form["txtSealName"].ToString().Trim();
                    string signerName = Request.Form["txtSignerName"].ToString().Trim();
                    string deptName = Request.Form["txtDeptName"].ToString().Trim();
                    string imageType = strImageType;
                    string sealType = Request.Form["SelectSealType"];
                    string authType = "密码";
                    strTmpPicPath = Request.Form["ipt_TmpPicPath"].ToString().Trim();
                    //将获取的印章图片转成byte
                    FileStream fs = new FileStream(strTmpPicPath, FileMode.Open);
                    byte[] byData = new byte[fs.Length];
                    fs.Read(byData, 0, byData.Length);
                    fs.Close();
                    imageBytes = byData;
                    int userId = 0;
                    Seals seal = new Seals();
                    bool bflg = false;//标识添加用户是否成功
                    try
                    {
                        //连接数据库查询Users表中是否存在当前签章用户,当userId=0就是不存在，如果userId不为0，则存在并返回当前userId
                        userId = existSingerName(signerName);
                        if (userId == 0)
                        {
                            Users user = new Users();
                            user.DeptID = 1;
                            if (deptName.Length > 0)
                            {
                                user.DeptName = deptName;
                                user.Password = GETMD5("111111"); ;
                                user.UserName = signerName;
                                user.RoleID = 1;
                                user.DeptID = 1;
                                user.CreateTime = DateTime.Now;
                                user.UpdateTime = DateTime.Now;
                                user.Status = "正常";
                                //添加用户
                                userId = addUser(user);
                            }
                            if (userId > 0)
                            {
                                bflg = true;
                            }
                            else
                            {
                                bflg = false;
                                errMsg += "用户添加失败！";
                            }
                        }
                        //System.out.println("sealId01");
                        //System.out.println("name:"+sealName+"sig:"+userId+signerName+"dept:"+deptName+"image:"+imageBytes+"type:"+imageType+"sealType:"+sealType);
                        //System.out.println("name:"+sealName+"signer:"+signerName+"dept:"+deptName+"type:"+imageType+"sealType:"+sealType);
                        seal.SealName = sealName;
                        seal.SignerID = userId;
                        seal.SignerName = signerName;
                        seal.DeptID = 1;
                        seal.DeptName = deptName;
                        seal.SealImage = imageBytes;
                        seal.SealImageType = imageType;
                        seal.SealType = sealType;
                        seal.Status = "颁发";
                        seal.CreateTime = DateTime.Now;
                        seal.UpdateTime = DateTime.Now;
                        seal.AuthType = authType;//System.out.println("01");
                        seal.Vcode = "749717320C36F2F526505680DDF2DB3268F58842";
                        int sealId = addSeal(seal);//System.out.println("sealId="+sealId);
                        //if  sealId>0,则签章添加成功
                        if (sealId > 0)
                        {
                            strImageType = "";
                            sucMsg = "印章添加成功！";
                            //印章添加成功后删除临时文件夹中的印章图片  
                            System.IO.File.Delete(strTmpPicPath);
                        }
                        else
                        {
                            errMsg += "印章添加失败！";
                            //删除新添加的用户
                            if (!bflg) {
                                delUser(userId);
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        errMsg += "印章添加失败，失败原因：" + e.Message;
                        //删除新添加的用户
                        //if(bflg){
                        //	if(!userManager.Delete(userId))
                        //		errMsg += "新添加的用户删除失败，请在数据库中手动删除！";
                        //}
                    }
                }
                if (errMsg.Trim().Length > 0)
                {
                    errMsgAdd = errMsg;
                    errMsg = "";
                }
            }


            //上传失败
            if (errMsgUpload.Length > 0) 
            {
                errMsg = "<script language=\"javascript\" type=\"text/javascript\">ShowAdd();setParamToInput();alert('" + errMsgUpload + "');</script>";
            }
            //上传成功时
            if (sucUploadMsg.Trim().Length > 0)
            {

                errMsg = "<script language=\"javascript\" type=\"text/javascript\">ShowAdd();setParamToInput(););</script>";
            }

            //添加印章失败时
            if (errMsgAdd.Length > 0)
                errMsg = "<script language=\"javascript\" type=\"text/javascript\">ShowAdd();setParamToInput();alert('" + errMsgAdd + "');</script>";

            //添加印章成功时
            if (sucMsg.Trim().Length > 0)
            {
                errMsg = "<script language=\"javascript\" type=\"text/javascript\">ShowList();clearContent();alert('添加成功！');</script>";
            }
            String delSucMsg = "";//标识删除印章成功信息
            //删除印章
            if (op != null && op.Trim().Equals("delete"))
            {
                string sid = Request.Query["id"];
                //confirmMsg = "你确认要删除编号为“"+id+"”的印章吗？";
                if (sid != null && sid.Trim().Length > 0)
                {
                    try
                    {
                        int id = int.Parse(sid);                       
                        bool delFlg=delSeal(id);
                        if (delFlg) {
                        delSucMsg = "印章删除成功";
                        }

                    }
                    catch (Exception e)
                    {
                        errMsg = "印章删除失败，失败原因：" + e.Message;
                    }
                }
            }

            if (delSucMsg.Trim().Length > 0)
                errMsg = "<script language=\"javascript\" type=\"text/javascript\">alert('" + errMsg + "');</script>";

            //删除印章成功时
            if (delSucMsg.Trim().Length > 0)
                errMsg = "<script language=\"javascript\" type=\"text/javascript\">ShowList();alert('删除成功！');</script>";

            List<Seals> sealList = new List<Seals>();
            string sql = "Select *  from Seals order by ID desc";
            using (SqliteConnection conn = new SqliteConnection(connString))
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                SqliteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Seals seal = new Seals();
                    seal.ID = int.Parse(dr["ID"].ToString());
                    seal.SealName = dr["SealName"].ToString();
                    seal.SealType = dr["SealType"].ToString();
                    seal.DeptID = int.Parse(dr["DeptID"].ToString());
                    seal.DeptName = dr["DeptName"].ToString();
                    seal.SignerID = int.Parse(dr["SignerID"].ToString());
                    seal.SignerName = dr["SignerName"].ToString();
                    seal.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
                    seal.UpdateTime = DateTime.Parse(dr["UpdateTime"].ToString());
                    seal.Status = dr["Status"].ToString();
                    seal.Description = dr["Description"].ToString();
                    MemoryStream streamImage = new MemoryStream(dr["SealImage"] as byte[]);
                    seal.SealImage = streamImage.ToArray();
                    seal.SealImageType = dr["SealImageType"].ToString();
                    seal.AuthType= dr["AuthType"].ToString();
                    /*seal.CertSerialNum= dr["CertSerialNum"].ToString();
                    seal.IssueTo= dr["IssueTo"].ToString();
                    seal.IssueBy= dr["IssueBy"].ToString();
                    seal.ValidFrom= dr["ValidFrom"].ToString();
                    seal.ValidTo= dr["ValidTo"].ToString();
                    seal.CertPKCS7= dr["CertPKCS7"].ToString();*/
                    sealList.Add(seal);
                }                
            }
            try
            {
                if (sealList.Count() > 0)
                {
                    flg = true;
                    for (int i = 0; i < sealList.Count(); i++)
                    {
                        strTable.Append("<tr style = 'color: #000066; height: 25px; border-color: #E7E7E7; border-width: 1px; border-style: solid; height: 40px; color:#666666' >\r\n");
                        strTable.Append("<td style='text-align: left; height: 40px; border-color: #E7E7E7; border-width: 1px; border-style: solid;'>" + sealList[i].ID + "</td>\r\n");
                        strTable.Append("<td><a href=\"javascript:void(0);\" style=\"color:#3366CC;\" onclick=\"showSealImg(this," + sealList[i].ID+ ")\">" + sealList[i].SealName + "</a>");
                        strTable.Append("<input type=\"hidden\" id=\"ipt_sealImgCode_" + sealList[i].ID + "\" ");
                        strTable.Append("value=\"" + "data:image/jpg;base64,"+ Convert.ToBase64String(sealList[i].SealImage) + "\" /></td>\r\n");
                        strTable.Append("<td>" + sealList[i].SealType + "</td>\r\n");
                        strTable.Append("<td>" + sealList[i].DeptName + "</td>\r\n");
                        strTable.Append("<td>" + sealList[i].Status + "</td>\r\n");
                        strTable.Append("<td>" + sealList[i].SignerName + "</td>\r\n");
                        String strDelLink = "<a href=\"AdminSeal?op=delete&id=" + sealList[i].ID + "\" onclick=\"if(confirm('你确认要删除编号为“" + sealList[i].ID + "”的印章吗？')) return true; return false;\" style=\"color:#3366CC\">删除</a>";
                        strTable.Append("<td>" + strDelLink + "</td>\r\n");
                        strTable.Append("</tr>\r\n");
                    }
                }
                else
                {
                    flg = false;
                    strTable.Append("<tr style=\"color: #000066; height: 25px; border-color: #A4C8DE; border-width: 1px; border-style: solid; height: 32px; color:#666666\">\r\n");
                    strTable.Append("<td colspan='7' style='text-align: center; color: #666666'> 无印章。</td>");
                    strTable.Append("</tr>\r\n");
                    //response.getWriter().write("<script > ShowDelAll();</script>");
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            String strTableRows = strTable.ToString();
            String strNowDate = DateTime.Now.ToString("yyyy/MM/dd");
            strAdminOutPage = OutPageStr(pathType);
            strAdminOutPage = strAdminOutPage.Replace("<%=userName %>",UserName);
            strAdminOutPage = strAdminOutPage.Replace("<%=strNowDate %>", strNowDate);
            strAdminOutPage = strAdminOutPage.Replace("<%=flg %>", flg.ToString());
            strAdminOutPage = strAdminOutPage.Replace("<%=addFlg %>",addFlg.ToString());
            strAdminOutPage = strAdminOutPage.Replace("<%=strTableRows %>",  strTableRows);
            strAdminOutPage = strAdminOutPage.Replace("<%=errMsg %>", errMsg);
            strAdminOutPage = strAdminOutPage.Replace("<%=strSealType %>",strSealType);
            strAdminOutPage = strAdminOutPage.Replace("<%=strSealName %>", strSealName);
            strAdminOutPage = strAdminOutPage.Replace("<%=strSingerName %>",strSingerName);
            strAdminOutPage = strAdminOutPage.Replace("<%=strDeptName %>",strDeptName);
            strAdminOutPage = strAdminOutPage.Replace("<%=strImageType %>", strImageType);
            if (strImgBase64 != "")
            {
                strAdminOutPage = strAdminOutPage.Replace("<%=strImgBase64 %>", "data:image/jpg;base64," + strImgBase64);
            }
            else {
                strAdminOutPage = strAdminOutPage.Replace("<%=strImgBase64 %>", "");
            }        
            strAdminOutPage = strAdminOutPage.Replace("<%=strTmpPicPath %>", strTmpPicPath);                                   
            var data = Encoding.UTF8.GetBytes(strAdminOutPage);
            await Response.Body.WriteAsync(data, 0, data.Length);

        }

        //获取登录页面（LoginSeal.dat）或者印章列表页面（AdminSeal.dat）的字符串
        private string OutPageStr(string pathType)
        {
            string strOutPage = "";
            FileStream fileStream = null;
            if (pathType.Contains("LoginSeal"))
            {
                fileStream = new FileStream(loginFilePath, FileMode.Open);
            }
            else
            {
                fileStream = new FileStream(adminFilePath, FileMode.Open);
            }
            char[] buffer = new char[1024];
            int len = 0;
            StringWriter outStream = new StringWriter();
            try
            {
                using (BinaryReader ins = new BinaryReader(fileStream, Encoding.UTF8))
                {
                    while ((len = ins.Read(buffer)) > 0)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            outStream.Write(buffer[i]);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            finally
            {
                outStream.Close();
                fileStream.Close();
            }
            strOutPage = outStream.ToString();
            //strOutPage = strOutPage.substring(2);//去掉？号
            strOutPage = strOutPage.Replace("text/html; charset=UTF-8", "text/html; charset=" + m_Charset);
            Response.ContentType = "text/html";
            return strOutPage;
        }

        //判断Users表中是否存在该用户
        private int existSingerName(string signerName) 
        {
         
            int userId = 0;
            string sql = "Select *  from Users Where UserName='"+ signerName+"'";
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connString))
                {
                    conn.Open();
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sql;
                    SqliteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Users user = new Users();
                        userId= int.Parse(dr["ID"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return userId;
        }
        //添加用户
        private int addUser(Users  user) {
            int userId = 0;
            string sql = "insert  into Users(UserName,PassWord,DeptId,DeptName,RoleID,CreateTime,UpdateTime,Status)Values('"+user.UserName+"'" + ",'"+
                user.Password+"',"+user.DeptID+ ",'"+user.DeptName+"',"+user.RoleID+",'"+user.CreateTime + "','" + user.UpdateTime + "','" + user.Status+"');";
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connString))
                {
                    conn.Open();
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    cmd.CommandText = sql;
                     userId=cmd.ExecuteNonQuery();
                    //如果userid>0,说明用户添加成功，接着查询当前用户的userId
                    if (userId > 0) {
                        cmd.CommandText = "Select *  from Users Where UserName='" + user.UserName + "'";
                        SqliteDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            userId = int.Parse(dr["ID"].ToString());
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }

            return userId;
        }
        //添加印章
        private int addSeal(Seals seal)
        {
            int sealId = 0;
            string sql = "insert  into Seals(SealName,SealType,DeptID,DeptName,SignerID,SignerName,CreateTime,UpdateTime,Status,AuthType,SealImage,SealImageType,Vcode)Values('" + seal.SealName + "','" +
                seal.SealType + "'," + seal.DeptID + ",'" + seal.DeptName + "'," + seal.SignerID + ",'" + seal.SignerName + "','"+ seal.CreateTime + "','" + seal.UpdateTime + "','" + seal.Status + "','"
               + seal.AuthType+ "'," + "@SealImage" + ",'"+ seal.SealImageType + "','"  + seal.Vcode+ "');";
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connString))
                {
                    conn.Open();
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SealImage",seal.SealImage);
                    sealId = cmd.ExecuteNonQuery();
                    //如果id>0,说明签章添加成功，接着查询当前签章的id
                    if (sealId > 0)
                    {
                        cmd.CommandText = "Select *  from Seals Where SealName='" + seal.SealName+ "'";
                        SqliteDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            sealId = int.Parse(dr["ID"].ToString());
                        }
                    }

                }  
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }

            return sealId;
        }

        //删除印章(根据印章ID删除印章)
        private bool delSeal(int sealId)
        {
           bool delFlg = false;
            string sql = "delete from Seals where ID= " + sealId;
            if (sealId > 0) {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(connString))
                {
                    conn.Open();
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    cmd.CommandText = sql;
                    sealId = cmd.ExecuteNonQuery();
                    //如果id>0,说明签章添加成功，接着查询当前签章的id
                    if (sealId > 0)
                    {
                            delFlg = true;
                    }

                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            }
            return  delFlg;
        }

        //删除用户(根据用户ID删除用户)
        private bool delUser(int userId)
        {
            bool delFlg = false;
            string sql = "delete from Users where ID= " + userId;
            if (userId > 0)
            {
                try
                {
                    using (SqliteConnection conn = new SqliteConnection(connString))
                    {
                        conn.Open();
                        SqliteCommand cmd = new SqliteCommand(sql, conn);
                        cmd.CommandText = sql;
                        userId = cmd.ExecuteNonQuery();
                        //如果id>0,说明签章添加成功，接着查询当前签章的id
                        if (userId > 0)
                        {
                            delFlg = true;
                        }

                    }
                }
                catch (Exception e)
                {
                    errMsg = e.Message;
                }
            }
            return delFlg;
        }

        /// netcore下的实现MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GETMD5(string password)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }

    }
    

}



